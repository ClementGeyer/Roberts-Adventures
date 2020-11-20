using UnityEngine;

namespace Controller
{
    public class CameraMovements : MonoBehaviour
    {
        [Header("Camera parameters")]
        [SerializeField] private float offsetCamera = 0.0f;
        [SerializeField] private float speedCamera = 0.05f;
        [SerializeField] private float increaseSpeedCamera = 0.05f;
        public float maxspeed; 
    
        public GameObject hero;
        private Transform tf;

        void Start()
        {
            tf = this.GetComponent<Transform>();
        }

   
        void FixedUpdate()
        {
            // Seuil de vitesse max
            if(speedCamera <= maxspeed)
                speedCamera *= 1+ increaseSpeedCamera;
        
            // Met à jour la position de la caméra tout en suivant le joueur sur l'axe y
            tf.position = new Vector3(  tf.position.x + speedCamera, tf.position.y,  tf.position.z);

            // Empêche la caméra de revenir en arrière
            if( tf.position.x < hero.GetComponent<Transform>().position.x )
                tf.position = new Vector3( hero.GetComponent<Transform>().position.x, tf.position.y,  tf.position.z);


            //Pour que la camera suive completement le joueur (pour les tests)
            /* tf.position = new Vector3( hero.GetComponent<Transform>().position.x, tf.position.y,  tf.position.z);
         
         tf.position = new Vector3(tf.position.x , hero.GetComponent<Transform>().position.y,  tf.position.z);*/
        
        
        }
    }
}