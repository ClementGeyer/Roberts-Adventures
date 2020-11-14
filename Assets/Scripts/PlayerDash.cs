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
    private int dashCoolDownBuffer;

    void Start()
    {
        canJump = false;
        dashCoolDownBuffer = sf_dashCooldown;
    }


    void FixedUpdate()
    {            
        dashCoolDownBuffer--;
        if(dashCoolDownBuffer < 0 && !canJump){
            dashCoolDownBuffer = sf_dashCooldown;
            canJump = true;
            Debug.Log("CAN JUMP");
        }

        if(Input.GetAxis("Jump") == 1 && canJump){
            canJump = false;
            sf_playerRB.velocity += sf_dashSpeed * new Vector2(1,0);
            dashCoolDownBuffer = sf_dashCooldown;
        }
    }
}
