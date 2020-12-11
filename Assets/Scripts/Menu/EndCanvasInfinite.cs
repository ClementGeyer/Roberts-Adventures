using System;
using Controller;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class EndCanvasInfinite : MonoBehaviour
    {
        public GameObject endMenuUI;
        public GameObject Map;
        public GameObject UI;
        public GameObject player;
        public CameraMovements cameraController;
        public TimeManager timeManager;
        public TextMeshProUGUI scoreText;
        public GameObject questionCanvas;
        public GameObject greetingsCanvas;
        public GameObject confetti;
        public GameObject panelEndMenu;

        /// <summary>
        /// Charge le menu principal
        /// </summary>
        public void MainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Quand le personnage reste dans le trigger, on désactive tout
        /// </summary>
        /// <param name="other"></param>
        void Update()
        {
            if(PlayerRespawn.playerDead){
                timeManager.EndTimer();
                player.SetActive(false);
                Map.SetActive(false);
                UI.SetActive(false);
                questionCanvas.SetActive(false);
                greetingsCanvas.SetActive(false);
                confetti.SetActive(true);
                panelEndMenu.SetActive(true);
                cameraController.setShouldMove(false);
                setScore();
            }
        }

        /// <summary>
        /// Permet au joueur de rejouer le niveau
        /// </summary>
        public void PlayAgain()
        {
            endMenuUI.SetActive(false);
            confetti.SetActive(false);
        }
        
        /// <summary>
        /// Met à jour le score dans l'interface de fin de niveau
        /// </summary>
        public void setScore()
        {
            scoreText.text = "Score : " + HUD.Score.score;
        }

    }
}