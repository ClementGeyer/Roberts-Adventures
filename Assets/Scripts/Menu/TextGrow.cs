using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
