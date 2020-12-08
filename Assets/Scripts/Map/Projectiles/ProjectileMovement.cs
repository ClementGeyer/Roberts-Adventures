using UnityEngine;

namespace Map.Projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            // Déplace le projectile de -0.2 sur l'axe x
            transform.position += new Vector3(-0.02f, 0, 0);
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
}