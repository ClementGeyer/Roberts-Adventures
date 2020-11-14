using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDash : MonoBehaviour
{

    
    [Header("Player rigidbody")]
    [SerializeField] private Rigidbody2D sf_playerRB;

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

        if(Input.GetAxis("Jump") == 1 && canJump){
            isDashing = true;
            canJump = false;
            isDashingCount = 25;
            sf_playerRB.velocity += sf_dashSpeed * new Vector2(1,0);
            dashCoolDownBuffer = sf_dashCooldown;
        }

        buffVelocity = sf_playerRB.velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if(col.gameObject.tag == "canBeDestroyed" && isDashing){
                //todo put here explosions and stuff
              Destroy(col.gameObject);
        }

        sf_playerRB.velocity= buffVelocity;
    }
}
