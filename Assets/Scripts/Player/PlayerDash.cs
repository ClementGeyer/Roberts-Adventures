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
    [SerializeField] private int sf_dashCooldown;
    

    private bool canJump;
    private bool isDashing;
    private int isDashingCount;
    private int dashCoolDownBuffer;

    Vector2 buffVelocity ;

    void Start()
    {
        
        canJump = false;
        isDashing = false;
        isDashingCount = 20;
        dashCoolDownBuffer = sf_dashCooldown;
    }


    void FixedUpdate()
    { 
        dash();
        buffVelocity = sf_playerRB.velocity;
    }

    void dash(){
        // Permet de récupérer la position de la souris dans la scène
        var worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        
        dashCoolDownBuffer--;


        if(isDashingCount <= 0){
            isDashing = false;
        }
        else{
            isDashingCount--;
        }
        
        if(dashCoolDownBuffer < 0 && !canJump){
            dashCoolDownBuffer = sf_dashCooldown;
            canJump = true;
        }

        if(Input.GetAxis("Jump") != 0 && canJump)
        {
            // Direction du dash calculée en fonction de la position de la souris et du personnage
            var direction = worldMousePosition - this.transform.position;
            direction.Normalize();

            RaycastHit2D hit = Physics2D.Raycast(firePoint.position, direction);
            if(hit.transform.gameObject.tag == "canBeDestroyed" && Vector2.Distance(hit.point, firePoint.position) <= maxDistance ){
                Destroy(hit.transform.gameObject);
            }
            
            isDashing = true;
            canJump = false;
            isDashingCount = 25;
            sf_playerRB.velocity += sf_dashSpeed * (Vector2)direction;
            dashCoolDownBuffer = sf_dashCooldown;
        }
    }
  
}
