using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject player;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 5f;
    
    public List<GameObject> levelPartList;

    public GameObject endPositionStart;

    private Vector3 lastEndPosition;
    
    
    void Awake()
    {
        lastEndPosition = endPositionStart.transform.position;
        SpawnLevelPart();
    }

    private void SpawnLevelPart()
    {
        GameObject chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(GameObject levelPart, Vector3 spawnPosition)
    {
        GameObject levelPartTransform = Instantiate(levelPart, spawnPosition + new Vector3(30, 0,0), Quaternion.identity);
        levelPartTransform.GetComponent<Transform>().SetParent(GameObject.Find("Map").transform);

        return levelPartTransform.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - lastEndPosition.x > 0.1f)
        {
            SpawnLevelPart();
        }
    }
}