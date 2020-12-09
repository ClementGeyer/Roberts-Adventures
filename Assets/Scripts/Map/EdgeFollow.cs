using System;
using UnityEngine;

public class EdgeFollow : MonoBehaviour
{
    public GameObject player;
    
    /// <summary>
    /// Permet aux bords du niveau de suivre le player
    /// </summary>
    private void Update()
    {
        var go = gameObject;
        var position = go.transform.position;
        
        position = new Vector3(player.transform.position.x, position.y, position.z);
        go.transform.position = position;
    }
}