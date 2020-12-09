using System;
using UnityEngine;

namespace Map.Projectiles
{
    public class ProjectileCreator : MonoBehaviour
    {
        // Point à partir duquel les projectiles doivent apparaître
        public Transform wayPoint;
        private Transform player;
        public GameObject projectile;
        public float[] yPositionProjectiles;
        private bool spawned;


        private void Start()
        {
            player = GameObject.Find("Player").transform;
        }

        /// <summary>
        /// Crée les projectiles lorsque le joueur est assez proche
        /// </summary>
        private void Update()
        {
            if (player.position.x >= wayPoint.position.x && !spawned)
            {
                // Création de 3 projectiles
                var position = wayPoint.position;
            
                for (int i = 0; i < yPositionProjectiles.Length; i++)
                {
                    Instantiate(projectile, position + new Vector3(50, yPositionProjectiles[i], 0), Quaternion.identity);
                }
            
                spawned = true;
            }
        }
    }
}
