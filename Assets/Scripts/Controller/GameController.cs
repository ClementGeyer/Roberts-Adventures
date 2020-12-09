using System;
using System.Collections.Generic;
using Map;
using Unity.Mathematics;
using UnityEngine;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        private GameObject player;
        public static List<bool> flowElements = new List<bool>();
        public static List<bool> selfefficiencyElements = new List<bool>();

 	    /// <summary>
        /// Démarre la partie et stocke le player présent dans la scène
        /// </summary>

        public void Start()
        {
            InitialiseLists();
            // Récupère le joueur
            player = GameObject.FindWithTag("Player");
            // Provisoire
            BeginGame();
            RemoveFlow();
            RemoveSelfEfficiency();
        }

        
        private void InitialiseLists()
        {
            for (int i = 0; i < 5; i++)
            {
                flowElements.Add(true);
            }
            
            for(int i=0;i<3;i++)
            {
                selfefficiencyElements.Add(true);
            }
        }
    
        /// <summary>
        /// Démarre la partie
        /// </summary>
        public void BeginGame()
        {
            // Lance le chronomètre
            TimeManager.instance.BeginTimer();
        }

        /// <summary>
        /// Désactive le flow
        /// </summary>
        public void DisableFlow() { flowElements[0] = !flowElements[0]; }

        /// <summary>
        /// Désactive le sentiment d'auto-efficacité
        /// </summary>
        public void DisableSelfEfficiency() { selfefficiencyElements[0] = !selfefficiencyElements[0]; }
        
        public void SetDash() { flowElements[1] = !flowElements[1]; }
        public void SetDashCooldown() { flowElements[2] = !flowElements[2]; }
        public void SetKillObstacles() { flowElements[3] = !flowElements[3]; }
        public void SetObstacleMovements() { flowElements[4] = !flowElements[4]; }
        public void SetCameraAcceleration() { flowElements[5] = !flowElements[5]; }

        public void SetBonuses() { selfefficiencyElements[1] = !selfefficiencyElements[1]; }
        public void SetEffects() { selfefficiencyElements[2] = !selfefficiencyElements[2]; }
        public void SetProgressionInfo() { selfefficiencyElements[3] = !selfefficiencyElements[3]; }


        /// <summary>
        /// Enlève des éléments du jeu propres au flow selon le choix du joueur
        /// </summary>
        private void RemoveFlow()
        {
            if (!flowElements[0])
            {
                DisableDash();
                DisableDashCoolDown();
                DisableMovementFromObstacles();
                DisableKillObstacles();
                DisableCameraAcceleration();
            }
            else
            {
                if (!flowElements[1])
                    DisableDash();
                else
                    EnableDash(); 
                if (!flowElements[2])
                    DisableDashCoolDown();
                else
                    EnableDashCoolDown();
                if (!flowElements[3])
                    DisableMovementFromObstacles();
                else
                    EnableMovementFromObstacles();
                if (!flowElements[4])
                    DisableKillObstacles();
                else
                    EnableKillObstacles();
                if (!flowElements[5])
                    DisableCameraAcceleration();
                else
                    EnableCameraAcceleration();
            }
        }

        /// <summary>
        /// Enlève des éléments du jeu propres au sentiment d'auto-efficacité selon le choix du joueur
        /// </summary>
        private void RemoveSelfEfficiency()
        {
            if (!selfefficiencyElements[0])
            {
                DisableBonuses();
                DisableEffects();
                DisableProgressionInfo();
            }
            else
            {
                if (!selfefficiencyElements[1])
                    DisableBonuses();
                else
                    EnableBonuses();
                if (!selfefficiencyElements[2])
                    DisableEffects();
                else
                    EnableEffects();
                if (!selfefficiencyElements[3])
                    DisableProgressionInfo();
                else
                    EnableProgressionInfo();
            }
        }

        /// <summary>
        /// Désactive le dash
        /// </summary>
        private void DisableDash()
        {
            // Désactive le script PlayerDash de Player
            player.GetComponent<PlayerDash>().enabled = false;
        }
        

        /// <summary>
        /// Supprime le délai d'attente avant de pouvoir réutiliser le dash
        /// </summary>
        private void DisableDashCoolDown()
        {
            // Récupère la variable sf_dashCooldown représentant le délai d'attente entre chaque dash
            player.GetComponent<PlayerDash>().sf_dashCooldown = 0;
        }

        /// <summary>
        /// Désactive les bonus
        /// </summary>
        private void DisableBonuses()
        {
            // Récupère tous les bonus
            GameObject[] bonuses =  GameObject.FindGameObjectsWithTag("bonusToHide");

            foreach (var bonus in bonuses)
            {
                // Désactive chaque bonus
                bonus.SetActive(false);
            }
        }

        /// <summary>
        /// Désactive les informations de progression, le temps, le pourcentage ainsi que la barre de progression.
        /// </summary>
        private void DisableProgressionInfo()
        {
            // Récupère les éléments du HUD relatif à la progression
            GameObject[] hudElems =  GameObject.FindGameObjectsWithTag("ProgressInfoToHide");
            
            foreach (var hud in hudElems)
            {
                // Désactive chaque élement
                hud.SetActive(false);
            }
        }
        
        /// <summary>
        /// Désactive les effets
        /// </summary>
        private void DisableEffects()
        {
            // Récupère tous les effets présents
            GameObject[] effects =  GameObject.FindGameObjectsWithTag("effectsToHide");
            
            foreach (var effect in effects)
            {
                // Désactive chaque effet
                effect.SetActive(false);
            }
        }
        
        /// <summary>
        /// Désactive le déplacement vertical des GameObject "MovingObstacles"
        /// </summary>
        private void DisableMovementFromObstacles()
        {
            // Récupère tous les obstacles qui se déplacent verticalement
            GameObject[] movingObstacles = GameObject.FindGameObjectsWithTag("movingObstacleToHide");

            foreach (var obstacle in movingObstacles)
            {
                // Désactive chaque obstacle
                obstacle.GetComponent<MovingObstacle>().enabled = false;
            }
        }

        /// <summary>
        /// Désactive la mort du joueur par la collision avec les obstacles
        /// </summary>
        private void DisableKillObstacles()
        {
            // Récupère tous les obstacles pouvant tuer le joueur
            GameObject[] killObstacles = GameObject.FindGameObjectsWithTag("canKillPlayer");

            foreach (var obstacle in killObstacles)
            {
                // Désactive chaque obstacle
                //obstacle.GetComponent<DeathZone>().enabled = false;
            }
        }
        
        /// <summary>
        /// Désactive l'accélération la caméra
        /// </summary>
        private void DisableCameraAcceleration()
        {
            // Récupère la caméra
            GameObject camScript = GameObject.FindWithTag("MainCamera");

            // Désactive l'accélération
            camScript.GetComponent<CameraMovements>().speedCamera = 0f;
            camScript.GetComponent<CameraMovements>().SpeedCameraBuff = 0f;
            camScript.GetComponent<CameraMovements>().increaseSpeedCamera = 0f;
        }
        
        /// <summary>
        /// Active le dash
        /// </summary>
        private void EnableDash()
        {
            // Désactive le script PlayerDash de Player
            player.GetComponent<PlayerDash>().enabled = true;
        }
        

        /// <summary>
        /// Active le délai d'attente avant de pouvoir réutiliser le dash
        /// </summary>
        private void EnableDashCoolDown()
        {
            // Récupère la variable sf_dashCooldown représentant le délai d'attente entre chaque dash
            player.GetComponent<PlayerDash>().sf_dashCooldown = 75;
        }

        /// <summary>
        /// Active les bonus
        /// </summary>
        private void EnableBonuses()
        {
            // Récupère tous les bonus
            GameObject[] bonuses =  GameObject.FindGameObjectsWithTag("bonusToHide");

            foreach (var bonus in bonuses)
            {
                // Désactive chaque bonus
                bonus.SetActive(true);
            }
        }

        /// <summary>
        /// Active les informations de progression, le temps, le pourcentage ainsi que la barre de progression.
        /// </summary>
        private void EnableProgressionInfo()
        {
            // Récupère les éléments du HUD relatif à la progression
            GameObject[] hudElems =  GameObject.FindGameObjectsWithTag("ProgressInfoToHide");
            
            foreach (var hud in hudElems)
            {
                // Désactive chaque élement
                hud.SetActive(true);
            }
        }
        
        /// <summary>
        /// Active les effets
        /// </summary>
        private void EnableEffects()
        {
            // Récupère tous les effets présents
            GameObject[] effects =  GameObject.FindGameObjectsWithTag("effectsToHide");
            
            foreach (var effect in effects)
            {
                // Désactive chaque effet
                effect.SetActive(true);
            }
        }
        
        /// <summary>
        /// Active le déplacement vertical des GameObject "MovingObstacles"
        /// </summary>
        private void EnableMovementFromObstacles()
        {
            // Récupère tous les obstacles qui se déplacent verticalement
            GameObject[] movingObstacles = GameObject.FindGameObjectsWithTag("movingObstacleToHide");

            foreach (var obstacle in movingObstacles)
            {
                // Désactive chaque obstacle
                obstacle.GetComponent<MovingObstacle>().enabled = true;
            }
        }

        /// <summary>
        /// Active la mort du joueur par la collision avec les obstacles
        /// </summary>
        private void EnableKillObstacles()
        {
            // Récupère tous les obstacles pouvant tuer le joueur
            GameObject[] killObstacles = GameObject.FindGameObjectsWithTag("canKillPlayer");

            foreach (var obstacle in killObstacles)
            {
                // Désactive chaque obstacle
                //obstacle.GetComponent<DeathZone>().enabled = true;
            }
        }
        
        /// <summary>
        /// Active l'accélération la caméra
        /// </summary>
        private void EnableCameraAcceleration()
        {
            // Récupère la caméra
            GameObject camScript = GameObject.FindWithTag("MainCamera");

            // Désactive l'accélération
            camScript.GetComponent<CameraMovements>().speedCamera = 0.04f;
            camScript.GetComponent<CameraMovements>().SpeedCameraBuff = 0.04f;
            camScript.GetComponent<CameraMovements>().increaseSpeedCamera = 0.0007f;
        }
        
    }
}
