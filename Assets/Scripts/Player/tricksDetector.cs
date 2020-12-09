using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tricksDetector : MonoBehaviour
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
 
    void Start()
    {
        playerTransform = this.gameObject.GetComponent<Transform>();
        timeToPrint /= 0.02f;
        bufferTimeToPrint = timeToPrint;
        hasToPrint = false;
    }

    private void FixedUpdate()
    {
        if(hasToPrint){
            timeToPrint--;
            if(timeToPrint <= 0){
                hasToPrint = false;
                timeToPrint = bufferTimeToPrint;
            }
        }
    }
    void Update()
    {
        int buffFlips = (int)flips;
        detectTricks();

        if(buffFlips != (int)flips){
            int idList = Random.Range(0, greetingsList.Count);
            greetingsText.GetComponent<TextMeshProUGUI>().text = greetingsList[idList];
            hasToPrint = true;
            currentRotation = 0;
            deltaRotation = 0;
            WindupRotation = 0;
        }

        
        greetingsText.SetActive(hasToPrint);
        
        
    }

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
