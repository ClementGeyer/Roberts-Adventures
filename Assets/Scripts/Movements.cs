using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

   // public GameObject Ga;
    private Rigidbody2D rb;

    void Start()
    {
        rb =  this.GetComponent<Rigidbody2D>();
    
    }


    void FixedUpdate()
    {
        if(rb.velocity.x < 5){
            rb.velocity = new Vector3(rb.velocity.x + 1, rb.velocity.y);
        }

        if(Input.GetAxis("Vertical")>0 &&  rb.velocity.y < 5) {

           rb.velocity = new Vector3(rb.velocity.x , rb.velocity.y + 3);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Lost todo check col tag name
       // Destroy(this);
    }
}
