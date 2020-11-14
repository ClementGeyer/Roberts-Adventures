using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject wheelOfDeath;
    public float rateOfSpawn = 5.0f;
    private float countRateOfSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(countRateOfSpawn > rateOfSpawn * 30) {
            Instantiate(wheelOfDeath, new Vector3(transform.position.x, transform.position.y, 0) + new Vector3(10, 0, 0), transform.rotation);
          
            countRateOfSpawn = 0;
        }
        countRateOfSpawn++;
        Debug.Log(countRateOfSpawn);
    }
}
