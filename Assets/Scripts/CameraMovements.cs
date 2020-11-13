using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public GameObject hero;
    public float offsetCamera = 10.0f;
    private Rigidbody2D rb;

    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
         
    }

   
    void FixedUpdate()
    {
        //if( this.GetComponent<Transform>().position.x - offsetCamera < hero.GetComponent<Transform>().position.x ){
           rb.velocity = new Vector3(hero.GetComponent<Rigidbody2D>().velocity.x, 0 ,-10);
        
        
    }
}
