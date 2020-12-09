using UnityEngine;

namespace Map.Projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {

        /// <summary>
        /// Déplace le projectile à chque frame
        /// </summary>
        void Update()
        {
            // Déplace le projectile de -0.2 sur l'axe x
            transform.position += new Vector3(-0.02f, 0, 0);
        }

        /// <summary>
        /// Détruit le projectile lorsqu'il sort de le camera
        /// </summary>
        void OnBecameInvisible () 
        {
            //Supprime le gameObject
            Destroy (gameObject);
            //Supprime l'isntance du script utilisé
            Destroy(this);
        }
    }
}