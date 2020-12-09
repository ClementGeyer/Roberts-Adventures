using UnityEngine;

namespace Player.GrapplingGun
{
    public class RopeColor : MonoBehaviour
    {
        [Header("Material Settings:")]
        [SerializeField] private Material ropeMaterial;
        [SerializeField] private int materialChangerate;

        private int materialChangerateBuffer;

        /// <summary>
        /// Se lance une fois dès l'appel du code
        /// </summary>
        void Start()
        {   
            //on set le buffer
            materialChangerateBuffer = materialChangerate;
        }

        /// <summary>
        /// Se lance une fois par Frame
        /// </summary>
        void Update()
        {
            //On décrémente le compteur
            materialChangerate--;
            if( materialChangerate < 0 ){
                //On prends une couleur au hasard
                Color newColor = new Color( Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                //Et on l'assigne
                materialChangerate = materialChangerateBuffer;
                ropeMaterial.color = newColor;
                ropeMaterial.SetColor("_EmissionColor",newColor);
            }
        
        }
    }
}
