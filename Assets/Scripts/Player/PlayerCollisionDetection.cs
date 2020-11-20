using System.Collections;
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
    
    [Header("Raycast2D origin")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private int maxDistance;
    [SerializeField] private string[] tagsOfKillingWalls;
    [SerializeField] private float distanceMinToBeDestroyed;

    private  RaycastHit2D hit;
    private  RaycastHit2D hitRight;
    private  RaycastHit2D hitBottom;
    private  RaycastHit2D hitLeft;

    private bool isDead;


    public void setDead(bool p_bool){
        isDead = p_bool;
    }

    /*Cette fonction commme son nom l'indique, va détecter si le joueur doit mourir.
    Il doit mourir si : il touche un objet destructible et qu'il ne dash pas*/
    void deadDetection(){

        /*On fait un raycast pour savoir si il touche quelque chose*
            Si oui on regarde son tag et si il correspond, alors on explose le joeuur et on fait apparaitre des particules*/

        hit = Physics2D.Raycast(firePoint.position,player.GetComponent<Rigidbody2D>().velocity, distanceMinToBeDestroyed);
        hitRight = Physics2D.Raycast(firePoint.position,new Vector3(1,0,0), distanceMinToBeDestroyed);
        hitBottom = Physics2D.Raycast(firePoint.position,Vector3.down, distanceMinToBeDestroyed);
        hitLeft = Physics2D.Raycast(firePoint.position,Vector3.left, distanceMinToBeDestroyed);
    
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
                camera.setShouldMove(false) ;
             }
        }
    }

    public void killPlayer(){
        //Permet de rendre le player inactif et de reset la corde (correction d'un bug)
        player.SetActive(false);
        player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().grappleRope.enabled = false;
        player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().m_springJoint2D.enabled = false;
        player.GetComponent<Transform>().Find("GunPivot/GrapplinGun").gameObject.GetComponent<GrapplingGun>().m_rigidbody.gravityScale = 1;
        
        isDead=true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        deadDetection();
    }
}
