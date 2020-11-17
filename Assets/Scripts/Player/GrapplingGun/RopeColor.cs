using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeColor : MonoBehaviour
{
    [Header("Material Settings:")]
    [SerializeField] private Material ropeMaterial ;
    [SerializeField] private int materialChangerate ;
    private int materialChangerateBuffer ;
    void Start()
    {
        materialChangerateBuffer = materialChangerate;
    }

    // Update is called once per frame
    void Update()
    {
        materialChangerate--;
        if( materialChangerate < 0 ){
            Color newColor = new Color( Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            materialChangerate = materialChangerateBuffer;
            ropeMaterial.color = newColor;
            ropeMaterial.SetColor("_EmissionColor",newColor);
        }
        
    }
}
