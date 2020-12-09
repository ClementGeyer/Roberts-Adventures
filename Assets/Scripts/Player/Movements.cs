using UnityEngine;

namespace Player
{
    public class Movements : MonoBehaviour
    {

     
        [Header("Set maximum speed")]
        [SerializeField]private float speedMax;

        private Rigidbody2D rb;
        private Vector2 v2;
        private Vector2 vDrag;


        /// <summary>
        /// Se lance une fois au début
        /// </summary>
        void Start()
        {
            //On set les valeurs 
            rb =  this.GetComponent<Rigidbody2D>();
            v2 = new Vector3(1,1);
            vDrag = new Vector3(0.8f,0.8f,0);
        }

        /// <summary>
        /// Se lance tout les 0.02 secondes (Basé sur le deltaTime)
        /// </summary>
        void FixedUpdate()
        {
            //Si la vitesse max est dépassée on la multiplie par une facteur inférieur à 1.
            if(rb.velocity.x > v2.x * speedMax || -rb.velocity.x < v2.x * -speedMax
            || rb.velocity.y > v2.y * speedMax || -rb.velocity.y < v2.y * -speedMax){
                rb.velocity *= vDrag;
            }
        }

        /// <summary>
        /// Lorsque le joueur passe en dehors de la caméra
        /// </summary>
        void OnBecameInvisible () 
        {
            this.gameObject.SetActive(false);
            //Destroy (gameObject);
           // Debug.Log("Destruction du joueur (sortie de la caméra)");
        }

    }
}
