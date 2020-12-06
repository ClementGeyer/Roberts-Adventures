using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDash : MonoBehaviour
{
    [Header("Player rigidbody")]
    [SerializeField] private Rigidbody2D sf_playerRB;

    [Header("Raycast2D origin")]
    [SerializeField] private Transform firePoint;
    
    [SerializeField] private int maxDistance;

    [Header("Values to change which affect the Dash")]
    [SerializeField] private float sf_dashSpeed;
    [SerializeField] public int sf_dashCooldown;
    
    [Header("Particules")]
    [SerializeField] private ParticleSystem  DeadParticules;
    [SerializeField] private ParticleSystem  DashParticules;
    [SerializeField] private float distanceMinToBeDestroyed;
  
    [HideInInspector] public bool canJump;
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
        buffVelocity = sf_playerRB.velocity;

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
                playDashSound();
                dashCoolDownBuffer = sf_dashCooldown;
            }
        }
    
    }
    
    private void playDashSound(){
        this.gameObject.GetComponent<AudioSource>().Play();
    }
  
}
