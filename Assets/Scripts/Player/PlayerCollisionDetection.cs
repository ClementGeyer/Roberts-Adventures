﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Controller.CameraMovements  camera;

    [Header("Player")]
    [SerializeField] private GameObject  player;
    
    [Header("Player Dash script")]
    [SerializeField] private PlayerDash  pDash;

    [Header("Particules")]
    [SerializeField] private ParticleSystem  DeadParticules;

    [Header("Time while you cant die")]
    [SerializeField] private float timeInvicibleRespawn;

    [Header("Raycast2D origin")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private int maxDistance;
    [SerializeField] private string[] tagsOfKillingWalls;
    [SerializeField] private float distanceMinToBeDestroyed;

    private  RaycastHit2D hit;
    private  RaycastHit2D hitRight;
    private  RaycastHit2D hitBottom;
    private  RaycastHit2D hitLeft;

    private float timeBuffer;
    private bool isDead;
    private static bool isInvicible;

    /// <summary>
    /// Met l'état joueur à la valeur du parametre 
    /// </summary>
    /// <param name="p_bool"> Boolean qui set la mort du personnage</param>
    public void setDead(bool p_bool){
        isDead = p_bool;
    }

    
    /// <summary>
    /// Cette méthode commme son nom l'indique, va détecter si le joueur doit mourir.
    /// Il doit mourir si : il touche un objet destructible et qu'il ne dash pas
    /// </summary>
    void deadDetection(){

        /*On fait un raycast pour savoir si il touche quelque chose*
            Si oui on regarde son tag et si il correspond, alors on explose le joeuur et on fait apparaitre des particules*/
        if(!isInvicible){
            hit         = Physics2D.Raycast(player.GetComponent<Transform>().position, player.GetComponent<Rigidbody2D>().velocity.normalized,    distanceMinToBeDestroyed);
            hitRight    = Physics2D.Raycast(player.GetComponent<Transform>().position, new Vector3(1,0,0),                             distanceMinToBeDestroyed);
            hitBottom   = Physics2D.Raycast(player.GetComponent<Transform>().position, Vector3.down,                                   distanceMinToBeDestroyed);
            hitLeft     = Physics2D.Raycast(player.GetComponent<Transform>().position, Vector3.left,                                   distanceMinToBeDestroyed);

         foreach(string tag in tagsOfKillingWalls ){   
            if( (hit        && hit.transform.gameObject.tag       == tag )
            ||  (hitRight   && hitRight.transform.gameObject.tag  == tag ) 
            ||  (hitBottom  && hitBottom.transform.gameObject.tag == tag )  
            ||  (hitLeft    && hitLeft.transform.gameObject.tag   == tag ) 
            &&   pDash.canJump && !isDead){
                if(!isDead){
                    Instantiate(DeadParticules, player.GetComponent<Transform>().position, Quaternion.identity);
                }
            
                killPlayer();
                camera.setShouldMove(false);
             }
        }
        }
      
    }


    /// <summary>
    /// Rend le joueur inactif 
    /// </summary>
    public void killPlayer(){
        //Permet de rendre le player inactif et de reset la corde (correction d'un bug)
        player.SetActive(false);
        player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().grappleRope.enabled = false;
        player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().m_springJoint2D.enabled = false;
        player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().m_rigidbody.gravityScale = 1;
        
        isDead=true;
    }


    /// <summary>
    /// Se lance tout les 0.02 secondes (Basé sur le deltaTime)
    /// </summary>
    void FixedUpdate()
    {
        if(isInvicible)
            timeInvicibleRespawn--;

        if(timeInvicibleRespawn < 0 && isInvicible){
            isInvicible = false;
            timeInvicibleRespawn = timeBuffer;
        }

        deadDetection();
    }

    public static void setInvicible(bool p_bool ){
        isInvicible = p_bool;
    }

    private void Start()
    {
        timeInvicibleRespawn = timeInvicibleRespawn / 0.02f;
        timeBuffer = timeInvicibleRespawn;
    }
}
