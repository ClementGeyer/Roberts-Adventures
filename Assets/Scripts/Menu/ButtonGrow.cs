using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class ButtonGrow : MonoBehaviour
    {
        // Start is called before the first frame update
        public RawImage btnImage;

        public void ButtonEnter()
        {
            btnImage.rectTransform.sizeDelta += new Vector2(15, 7);
        }
    
        public void ButtonLeave()
        {
            btnImage.rectTransform.sizeDelta -= new Vector2(15, 7);
        }
    
        public void IconeEnter()
        {
            btnImage.rectTransform.sizeDelta += new Vector2(15, 15);
        }
    
        public void IconeLeave()
        {
            btnImage.rectTransform.sizeDelta -= new Vector2(15, 15);
        }
    }
}
