using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {

        public GameObject menu;

        /// <summary>
        /// Charge le menu de sélection des niveaux
        /// </summary>
        public void LoadLevelSelection()
        {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// Quitte le jeu
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// Charge le menu des options
        /// </summary>
        public void LoadOptionsMenu()
        {
            menu.SetActive(true);
        }
    }
}
