using System;
using UnityEngine;
using UnityEngine.UI;

namespace Map.Projectiles
{
    public class ProjectileCreator : MonoBehaviour
    {
        // Point à partir duquel les projectiles doivent apparaître
        public Transform wayPoint;
        private Transform player;
        public GameObject projectile;
        private Transform hud;
        public Image warning;
        public float[] yPositionProjectiles;
        private bool spawned;


        private void Start()
        {
            player = GameObject.Find("Player").transform;
            hud = GameObject.Find("Canvas").transform;
        }

        /// <summary>
        /// Crée les projectiles lorsque le joueur est assez proche
        /// </summary>
        private void Update()
        {
            if (player.position.x >= wayPoint.position.x && !spawned)
            {
                // Création des projectiles
                var position = wayPoint.position;
            
                for (int i = 0; i < yPositionProjectiles.Length; i++)
                {
                    Instantiate(projectile, position + new Vector3(50, yPositionProjectiles[i], 0), Quaternion.identity);
                    var positionHud = hud.position;
                    Image warningHud = Instantiate(warning, new Vector3(positionHud.x+11, yPositionProjectiles[i]+4, positionHud.z), Quaternion.identity);

                    warningHud.GetComponent<Transform>().SetParent(hud.transform);
                }
            
                spawned = true;
            }
        }
    }
}
