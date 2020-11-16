using System;
using UnityEngine;

public class ProjectileCreator : MonoBehaviour
{
    public Transform wayPoint;
    public Transform player;
    public GameObject projectile;
    private bool spawned = false;

    private void Update()
    {
        if (player.position.x >= wayPoint.position.x && !spawned)
        {
            Instantiate(projectile, wayPoint.position + new Vector3(340, 0, 0), Quaternion.identity);
            Instantiate(projectile, wayPoint.position + new Vector3(340, 20, 0), Quaternion.identity);
            Instantiate(projectile, wayPoint.position + new Vector3(340, 40, 0), Quaternion.identity);
            spawned = true;
        }
    }
}
