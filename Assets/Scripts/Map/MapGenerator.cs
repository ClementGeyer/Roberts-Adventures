using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject player;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 5f;
    
    public List<Transform> levelPartList;

    public GameObject endPositionStart;

    private Vector3 lastEndPosition;
    
    
    void Awake()
    {
        lastEndPosition = endPositionStart.transform.position;
        SpawnLevelPart();
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition + new Vector3(30, 0,0), Quaternion.identity);
        levelPartTransform.SetParent(GameObject.Find("Map").transform);

        return levelPartTransform;
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