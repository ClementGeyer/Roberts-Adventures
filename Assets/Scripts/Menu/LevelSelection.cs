using System;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class LevelSelection : MonoBehaviour
    {
        //Cet attribut est le pannel du prefab "Options"
        public GameController gc;
        public GameObject optionsMenu;
        public Toggle flow;
        public Toggle selfefficiency;


        private void Start()
        {
            int i = 0;
            foreach (var toggle in flow.GetComponentsInChildren<Toggle>())
            {
                if (!GameController.flowElements[i])
                {
                    toggle.isOn = false;
                    GameController.flowElements[i] = false;
                }
                i++;
            }
            
            i = 0;
            foreach (var toggle in selfefficiency.GetComponentsInChildren<Toggle>())
            {
                if (!GameController.selfefficiencyElements[i])
                {
                    toggle.isOn = false;
                    GameController.selfefficiencyElements[i] = false;
                }
                i++;
            }
        }

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
