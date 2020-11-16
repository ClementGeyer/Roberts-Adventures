using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.1f, 0, 0);
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
}