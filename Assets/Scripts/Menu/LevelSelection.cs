using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class LevelSelection : MonoBehaviour
    {
        //Cet attribut est le pannel du prefab "Options"
        public GameObject optionsMenu;
    
        //Cette méthode permet de charger le niveau correspondant à l'index du bouton dans le buildIndex
        public void LoadLevel(int lvlIndex)
        {
            SceneManager.LoadScene(lvlIndex);
        }

        //Cette méthode permet de charger le menu principal en appuyant sur la flèche
        public void BackArrow()
        {
            SceneManager.LoadScene(0);
        }
    
        // cette méthode permet de charger le menu des options
        public void LoadOptionsMenu()
        {
            optionsMenu.SetActive(true);
        }
    }
}
