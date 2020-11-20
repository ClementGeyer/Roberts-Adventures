using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Progression : MonoBehaviour
{

    [Header("Text to change")]
    [SerializeField] private Text sf_text;
    [Header("Transform of Start and Finish objects:")]
    [SerializeField] private Transform sf_start;
    [SerializeField] private Transform sf_finish;
    [Header("Transform of the player:")]
    [SerializeField] private GameObject sf_player;
   


    // Start is called before the first frame update
    void Start()
    {
        sf_text.text =  0 + " %";
    }

    // Update is called once per frame
    void Update()
    {

        if(sf_player != null){
            float length = (sf_finish.position.x - sf_start.position.x);
            int posPlayer = (int)((sf_player.GetComponent<Transform>().position.x/ length ) * 100);

            if(posPlayer < 0 )
                posPlayer = 0;
            else if(posPlayer > 100)
                posPlayer = 100;

            sf_text.text =  posPlayer + " %";
        }
            
    }
}
