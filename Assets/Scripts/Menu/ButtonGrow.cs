using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class ButtonGrow : MonoBehaviour
    {
        // Start is called before the first frame update
        public RawImage btnImage;

        /// <summary>
        /// Change la taille du bouton en entrée du curseur
        /// </summary>
        public void ButtonEnter()
        {
            btnImage.rectTransform.sizeDelta += new Vector2(15, 7);
        }
    
        /// <summary>
        /// Change la taille du bouton en sortie du curseur
        /// </summary>
        public void ButtonLeave()
        {
            btnImage.rectTransform.sizeDelta -= new Vector2(15, 7);
        }
    
        /// <summary>
        /// Change la taille de l'icone en entrée du curseur
        /// </summary>
        public void IconeEnter()
        {
            btnImage.rectTransform.sizeDelta += new Vector2(15, 15);
        }
    
        /// <summary>
        /// Change la taille de l'icone en sortie du curseur
        /// </summary>
        public void IconeLeave()
        {
            btnImage.rectTransform.sizeDelta -= new Vector2(15, 15);
        }
    }
}
