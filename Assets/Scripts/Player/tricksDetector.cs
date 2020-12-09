using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TricksDetector : MonoBehaviour
{
    [Header("Text for greetings")]
    [SerializeField]private GameObject greetingsText;
    [SerializeField]private List<string> greetingsList;
    [SerializeField]private float timeToPrint;

    private bool hasToPrint;
    private Transform playerTransform;
    float flips = 0;
    float deltaRotation = 0;
    float currentRotation = 0;
    float WindupRotation = 0;
    float bufferTimeToPrint = 0;
 

    /// <summary>
    /// Se lance une seule fois au début
    /// </summary>
    void Start()
    {
        playerTransform = this.gameObject.GetComponent<Transform>();
        timeToPrint /= 0.02f;
        bufferTimeToPrint = timeToPrint;
        hasToPrint = false;
    }

    /// <summary>
    /// Se lance tout les 0.02 secondes (Basé sur le deltaTime)
    /// </summary>
    private void FixedUpdate()
    {
        //Si on doit l'afficher
        if(hasToPrint){
            timeToPrint--;
            //Et que on a encore le temps pour l'afficher
            if(timeToPrint <= 0){
                hasToPrint = false;
                timeToPrint = bufferTimeToPrint;
            }
        }
    }

    /// <summary>
    /// Est appelé une fois par frame
    /// </summary>
    void Update()
    {
        //On crée un buffer
        int buffFlips = (int)flips;
        //On regarde le nombre de flips
        detectTricks();

        //Si le buffer est devenu différents
        if(buffFlips != (int)flips){
            //On prends une valeur aléatoire
            int idList = Random.Range(0, greetingsList.Count);  
            //On set le texte sur une des valeurs de la liste
            greetingsText.GetComponent<TextMeshProUGUI>().text = greetingsList[idList];
            hasToPrint = true;
            currentRotation = 0;
            deltaRotation = 0;
            WindupRotation = 0;
        }

        
        greetingsText.SetActive(hasToPrint);
        
        
    }


    /// <summary>
    /// Detecte si le joueur à fait un flip
    /// </summary>
    void detectTricks(){
        
        deltaRotation = (currentRotation - playerTransform.eulerAngles.z);
        currentRotation = playerTransform.eulerAngles.z;

        if (deltaRotation >= 300) 
            deltaRotation -= 360;
        if (deltaRotation <= -300) 
            deltaRotation += 360;

        WindupRotation += (deltaRotation);

        
        flips = WindupRotation / 360;
       
    }
}
