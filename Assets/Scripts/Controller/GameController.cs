﻿using System;
using Map;
using UnityEngine;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        private GameObject player;
        private static bool flow = true;
        private static bool selfefficiency = true;
        
        /// <summary>
        /// Démarre la partie et stocke le player présent dans la scène
        /// </summary>
        public void Start()
        {
            // Récupère le joueur
            player = GameObject.FindWithTag("Player");
            // Provisoire
            BeginGame();
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
        public void DisableFlow()
        {
            flow = !flow;
        }
        
        /// <summary>
        /// Désactive le sentiment d'auto-efficacité
        /// </summary>
        public void DisableSelfEfficiency()
        {
            selfefficiency = !selfefficiency;
        }
        
        /// <summary>
        /// Enlève des éléments du jeu propres au flow selon le choix du joueur
        /// </summary>
        public void RemoveFlow()
        {
            if (!flow)
            {
                DisableDash();
                DisableDashCoolDown();
                DisableMovementFromObstacles();
                DisableKillObstacles();
                DisableCameraAcceleration();
            }
        }
        
        /// <summary>
        /// Enlève des éléments du jeu propres au sentiment d'auto-efficacité selon le choix du joueur
        /// </summary>
        public void RemoveSelfEfficiency()
        {
            if (!selfefficiency)
            {
                DisableBonuses();
                DisableEffects();
                DisableProgressionInfo();
            }
        }
        
        /// <summary>
        /// Réactive tous les élements du jeu
        /// </summary>
        public void EnableAll()
        {
            EnableDash();
            EnableDashCoolDown();
            EnableMovementFromObstacles();
            EnableKillObstacles();
            EnableCameraAcceleration();
            EnableBonuses();
            EnableEffects();
            EnableProgressionInfo();
            flow = true;
            selfefficiency = true;
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
            // Récupère le gameController contenant le script à désactiver
            GameObject gameController = GameObject.Find("GameController");
            
            // Désactive le script
            gameController.GetComponent<PlayerCollisionDetection>().enabled = false;
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
            // Récupère le gameController contenant le script à désactiver
            GameObject gameController = GameObject.Find("GameController");
            
            // Active le script
            gameController.GetComponent<PlayerCollisionDetection>().enabled = true;
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
