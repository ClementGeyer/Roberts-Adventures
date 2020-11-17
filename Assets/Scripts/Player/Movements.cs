using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

     
    [Header("Set maximum speed")]
    [SerializeField]private float speedMax;

    private Rigidbody2D rb;
    private Vector2 v2;
    private Vector2 vDrag;

    void Start()
    {
        rb =  this.GetComponent<Rigidbody2D>();
        v2 = new Vector3(1,1);
        vDrag = new Vector3(0.8f,0.8f,0);
    }


    void FixedUpdate()
    {
      if(rb.velocity.x > v2.x * speedMax || -rb.velocity.x < v2.x * -speedMax
        || rb.velocity.y > v2.y * speedMax || -rb.velocity.y < v2.y * -speedMax){
        rb.velocity *= vDrag;
      }
    }
    
    // Lorsque le joueur sort de le camera
    void OnBecameInvisible () 
    {
        //Destroy (gameObject);
        Debug.Log("Destruction du joueur (sortie de la caméra)");
    }

}
