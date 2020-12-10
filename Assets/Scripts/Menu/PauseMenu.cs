using System;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GamePaused = false;
        public GameObject PauseMenuUI;


        /// <summary>
        /// Désactive le menu pause au lancement du niveau
        /// </summary>
        private void Start()
        {
            PauseMenuUI.SetActive(false);
        }

        /// <summary>
        /// Vérifie si l'utilisateur appuie sur 'Escape'
        /// </summary>
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Si le jeu est en pause on reprend le jeu
                if (GamePaused)
                {
                    Resume();
                }
                //Sinon on affiche le menu pause
                else
                {
                    Pause();
                }
            }
        }

        /// <summary>
        /// Relance le jeu
        /// </summary>
        public void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
        }

        /// <summary>
        /// Affiche le menu pause
        /// </summary>
        void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }

        /// <summary>
        /// Quitte le niveau
        /// </summary>
        public void QuitGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
