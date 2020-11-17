using System;
using UnityEngine;

public class ProjectileCreator : MonoBehaviour
{
    // Point à partir duquel les projectiles doivent apparaître
    public Transform wayPoint;
    public Transform player;
    public GameObject projectile;
    private bool spawned;

    private void Update()
    {
        if (player.position.x >= wayPoint.position.x && !spawned)
        {
            // Création de 3 projectiles
            var position = wayPoint.position;
            Instantiate(projectile, position + new Vector3(340, 0, 0), Quaternion.identity);
            Instantiate(projectile, position + new Vector3(340, 20, 0), Quaternion.identity);
            Instantiate(projectile, position + new Vector3(340, 40, 0), Quaternion.identity);
            spawned = true;
        }
    }
}
