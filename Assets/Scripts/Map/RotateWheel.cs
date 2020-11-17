using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public float wheelRotationSpeed = 5.0f;
     private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        rb.MoveRotation( GetComponent<Rigidbody2D>().rotation +wheelRotationSpeed);
    }
}
