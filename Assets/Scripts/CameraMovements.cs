using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public GameObject hero;
    public float offsetCamera = 10.0f;
    private Transform tf;

    void Start()
    {
         tf = this.GetComponent<Transform>();
         
    }

   
    void FixedUpdate()
    {
        if( tf.position.x < hero.GetComponent<Transform>().position.x )
           tf.position = new Vector3(   hero.GetComponent<Transform>().position.x, tf.position.y,  tf.position.z);
        
        
    }
}
