using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGrow : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage btnImage;

    public void MouseEnter()
    {
        btnImage.rectTransform.sizeDelta += new Vector2(15, 7);
    }
    
    public void MouseLeave()
    {
        btnImage.rectTransform.sizeDelta -= new Vector2(15, 7);
    }
}
