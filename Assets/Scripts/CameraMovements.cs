using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [Header("Camera parameters")]
    [SerializeField] private float offsetCamera = 0.0f;
    [SerializeField] private float speedCamera = 0.05f;
    [SerializeField] private float increaseSpeedCamera = 0.05f;
    
    public GameObject hero;
    private Transform tf;

    void Start()
    {
         tf = this.GetComponent<Transform>();
         
    }

   
    void FixedUpdate()
    {
        
        /*speedCamera *= 1+ increaseSpeedCamera;
        tf.position = new Vector3(  tf.position.x + speedCamera, tf.position.y,  tf.position.z);

        if( tf.position.x < hero.GetComponent<Transform>().position.x )
           tf.position = new Vector3( hero.GetComponent<Transform>().position.x, tf.position.y,  tf.position.z);*/


        //Pour que la camera suive completement le joueur (pour les tests)
        tf.position = new Vector3( hero.GetComponent<Transform>().position.x, tf.position.y,  tf.position.z);
        
        tf.position = new Vector3(tf.position.x , hero.GetComponent<Transform>().position.y,  tf.position.z);
        
        
    }
}
