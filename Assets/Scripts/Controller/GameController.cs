using Map;
using UnityEngine;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        private GameObject player;
        public void Start()
        {
            // Récupère le joueur
            player = GameObject.FindWithTag("Player");
            // Provisoire
            BeginGame();
            DisableDashCoolDown();
        }
    
        // Démarre la partie
        public void BeginGame()
        {
            // Lance le chronomètre
            TimeManager.instance.BeginTimer();
        }

        // Désactive le dash
        private void DisableDash()
        {
            // Désactive le script PlayerDash de Player
            player.GetComponent<PlayerDash>().enabled = false;
        }

        // Supprime le délai d'attente avant de pouvoir réutiliser le dash
        private void DisableDashCoolDown()
        {
            // Récupère la variable sf_dashCooldown représentant le délai d'attente entre chaque dash
            player.GetComponent<PlayerDash>().sf_dashCooldown = 0;
        }

        // Désactive les bonus
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

        // Désactive les informations de progression, le temps, le pourcentage ainsi que la barre de progression.
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
        
        // Désactive les effets
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
        
        // Désactive le déplacement vertical des GameObject "MovingObstacles"
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

        // Désactive la mort du joueur par la collision avec les obstacles
        private void DisableKillObstacles()
        {
            // Récupère tous les obstacles pouvant tuer le joueur
            GameObject[] killObstacles = GameObject.FindGameObjectsWithTag("canKillPlayer");

            foreach (var obstacle in killObstacles)
            {
                // Désactive chaque obstacle
                obstacle.GetComponent<DeathZone>().enabled = false;
            }
        }
        
        //Désactive l'accélération la caméra
        private void DisableCameraAcceleration()
        {
            // Récupère la caméra
            GameObject camScript = GameObject.FindWithTag("MainCamera");

            // Désactive l'accélération
            camScript.GetComponent<CameraMovements>().speedCamera = 0f;
            camScript.GetComponent<CameraMovements>().SpeedCameraBuff = 0f;
            camScript.GetComponent<CameraMovements>().increaseSpeedCamera = 0f;
        }
        
    }
}
