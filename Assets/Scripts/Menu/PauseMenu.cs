using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        //Cet attribut définit si le menu pause est activé ou non
        public static bool GamePaused = false;
        //Cet attribut représente le pannel du menu pause
        public GameObject PauseMenuUI;

        //La fonction start va désactiver le menu pause au démarrage du niveau
        private void Start()
        {
            PauseMenuUI.SetActive(false);
        }

        // La fontion update permet de déterminer à chaque frame si un input de type "touche Escape" est présent
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

        //Méthode permettant de désactiver le menu pause, on remettera aussi le temps du jeu à la normale
        public void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            //Time.fixedDeltaTime = 1f;
            GamePaused = false;
        }

        //Méthode permettant de montrer le menu pause et de désactiver le temps du jeu pour ne plus pouvoir joueur
        void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            //Time.fixedDeltaTime = 0f;
            GamePaused = true;
        }

        //Méthode permettant de quitter le niveau, on réactive aussi le temps sinon quand on relance le niveau le temps sera désactiver
        public void QuitGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
