using TMPro;
using UnityEngine;

namespace Menu
{
    public class TextGrow : MonoBehaviour
    {

        public TextMeshProUGUI text;

        public void MouseEnter()
        {
            text.fontSize += 4;
        }
    
        public void MouseLeave()
        {
            text.fontSize -= 4;
        }
    }
}
