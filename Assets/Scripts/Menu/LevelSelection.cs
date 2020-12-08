using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class LevelSelection : MonoBehaviour
    {
        //Cet attribut est le pannel du prefab "Options"
        public GameObject optionsMenu;
        public Toggle flow;
        public Toggle selfefficiency;
    
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

        public void FlowClick()
        {
            foreach (var toggle in flow.GetComponentsInChildren<Toggle>())
            {
                if (toggle.name != "FlowToggle")
                    toggle.isOn = flow.isOn;
            }
        }
        
        public void SelEfficiencyClick()
        {
            foreach (var toggle in selfefficiency.GetComponentsInChildren<Toggle>())
            {
                if (toggle.name != "SelfEfficiencyToggle")
                    toggle.isOn = selfefficiency.isOn;
            }
        }
    }
}
