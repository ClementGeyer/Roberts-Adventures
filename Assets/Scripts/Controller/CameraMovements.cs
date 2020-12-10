using UnityEngine;

namespace Controller
{
    public class CameraMovements : MonoBehaviour
    {
        [Header("Camera parameters")]
        [SerializeField] public float speedCamera = 0.05f;
        [SerializeField] public float increaseSpeedCamera = 0.05f;
        public bool shouldMove;
        [SerializeField] public float SpeedCameraBuff = 0.0f;
        public float maxspeed; 
    
        public GameObject hero;
        private Transform tf;

        public void setShouldMove(bool p_b){
            shouldMove = p_b;
        }
        void Start()
        {
            speedCamera = SpeedCameraBuff;
            // shouldMove = true;
            tf = this.GetComponent<Transform>();
        }

    
        void FixedUpdate()
        {
          moveCamera();
        }

        /// <summary>Cette méthode permet de bouger la caméra en fonction du joueur et du temps qui passe
        /// <example>Par exemple:
        /// <code>
        ///    Position playerPosition = new Point(3,5);
        ///    Camera.Translate(playerPosition + acceleration);
        /// </code>
        ///     Cela permet de suivre le joueur tout en accelerant la caméra
        /// </example>
        /// </summary>
        private void moveCamera(){
            if(shouldMove){
                // Seuil de vitesse max
                if(speedCamera <= maxspeed)
                    speedCamera *= 1+ increaseSpeedCamera;
            
                // Met à jour la position de la caméra tout en suivant le joueur sur l'axe y
                tf.position = new Vector3(  tf.position.x + speedCamera, tf.position.y,  tf.position.z);

                // Empêche la caméra de revenir en arrière
                if( tf.position.x < hero.GetComponent<Transform>().position.x )
                    tf.position = new Vector3( hero.GetComponent<Transform>().position.x, tf.position.y,  tf.position.z);
            }
        }
    }
}