using TMPro;
using UnityEngine;

namespace Menu
{
    public class TextGrow : MonoBehaviour
    {

        public TextMeshProUGUI text;

        /// <summary>
        /// Change la taille du texte en entrée du curseur
        /// </summary>
        public void MouseEnter()
        {
            text.fontSize += 4;
        }
    
        /// <summary>
        /// Change la taille du texte en sortie du curseur
        /// </summary>
        public void MouseLeave()
        {
            text.fontSize -= 4;
        }
    }
}
