using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Déplace le projectile de -0.2 sur l'axe x
        transform.position += new Vector3(-0.2f, 0, 0);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifie que l'objet entrant en collision est bien le joueur
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Destruction du joueur par le projectile");
        }
    }
    
    // Lorsque le projectile sort de le camera
    void OnBecameInvisible () 
    {
        //Supprime le gameObject
        Destroy (gameObject);
        //Supprime l'isntance du script utilisé
        Destroy(this);
    }
}