﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDash : MonoBehaviour
{
    [Header("Player rigidbody")]
    [SerializeField] private Rigidbody2D sf_playerRB;

    [Header("Raycast2D origin")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private int maxDistance;
    [SerializeField] private string tagOfKillingWalls;

    [Header("Values to change which affect the Dash")]
    [SerializeField] private float sf_dashSpeed;
    [SerializeField] private int sf_dashCooldown;
    
    [Header("Particules")]
    [SerializeField] private ParticleSystem  DeadParticules;
    [SerializeField] private ParticleSystem  DashParticules;
    [SerializeField] private float distanceMinToBeDestroyed;
  
    private bool canJump;
    private int dashCoolDownBuffer;

    private Vector2 buffVelocity ;


    void Start()
    {
        
        canJump = false;
        dashCoolDownBuffer = sf_dashCooldown;
    }


    void FixedUpdate()
    { 
        dash();
        deadDetection();
        buffVelocity = sf_playerRB.velocity;

    }


    /*Cette fonction commme son nom l'indique, va détecter si le joueur doit mourir.
    Il doit mourir si : il touche un objet destructible et qu'il ne dash pas*/
    void deadDetection(){

        /*On fait un raycast pour savoir si il touche quelque chose*
            Si oui on regarde son tag et si il correspond, alors on explose le joeuur et on fait apparaitre des particules*/

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position,sf_playerRB.velocity, distanceMinToBeDestroyed);
    
        if(hit && hit.transform.gameObject.tag == tagOfKillingWalls && canJump ){
            Instantiate(DeadParticules, this.transform.position, Quaternion.identity);
            killPlayer();
        }

    }

    void killPlayer(){
        this.gameObject.SetActive(false);
        this.transform.Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().grapplePoint = new Vector2(this.transform.position.x,this.transform.position.y);
    }

    void dash(){
        if(sf_playerRB != null && firePoint != null ){
            // Permet de récupérer la position de la souris dans la scène
            var worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
            
            dashCoolDownBuffer--;

            if(dashCoolDownBuffer < 0 && !canJump){
                dashCoolDownBuffer = sf_dashCooldown;
                canJump = true;
            }

            if(Input.GetAxis("Jump") != 0 && canJump)
            {
                // Direction du dash calculée en fonction de la position de la souris et du personnage
                var direction = worldMousePosition - this.transform.position;
                direction.Normalize();
                
                RaycastHit2D hit = Physics2D.Raycast(firePoint.position, sf_playerRB.velocity, maxDistance);
                if(hit && hit.transform.gameObject.tag == "canBeDestroyed" && Vector2.Distance(hit.point, firePoint.position) <= maxDistance ){
                  hit.transform.gameObject.SetActive(false);
                }

                canJump = false;
                sf_playerRB.velocity += sf_dashSpeed * (Vector2)direction;
                DashParticules.Play();
                dashCoolDownBuffer = sf_dashCooldown;
            }
        }
    
    }
  
}
