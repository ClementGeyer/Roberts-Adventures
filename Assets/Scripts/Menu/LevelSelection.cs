using System;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class LevelSelection : MonoBehaviour
    {
        public GameObject optionsMenu;
        public Toggle flow;
        public Toggle selfefficiency;

        /// <summary>
        /// Quand on charge la scène, vérifie que les toggle sont bien désactivés pour les éléments désactivés
        /// </summary>
        private void Start()
        {
            int i = 0;
            // On parcours le tableau des élements du flow
            foreach (var toggle in flow.GetComponentsInChildren<Toggle>())
            {
                // Si ils sont désactivés on désactive le toggle
                if (!GameController.flowElements[i])
                {
                    toggle.isOn = false;
                    GameController.flowElements[i] = false;
                }
                i++;
            }
            
            i = 0;
            // On parcours le tableau des élements du l'auto efficacité
            foreach (var toggle in selfefficiency.GetComponentsInChildren<Toggle>())
            {
                // Si ils sont désactivés on désactive le toggle
                if (!GameController.selfefficiencyElements[i])
                {
                    toggle.isOn = false;
                    GameController.selfefficiencyElements[i] = false;
                }
                i++;
            }
        }

        /// <summary>
        /// Charge le niveau envoyé en paramètre
        /// </summary>
        /// <param name="lvlIndex"></param>
        public void LoadLevel(int lvlIndex)
        {
            SceneManager.LoadScene(lvlIndex);
        }

        /// <summary>
        /// Retourne au menu principal
        /// </summary>
        public void BackArrow()
        {
            SceneManager.LoadScene(0);
        }
    
        /// <summary>
        /// Charge le menu des options
        /// </summary>
        public void LoadOptionsMenu()
        {
            optionsMenu.SetActive(true);
        }

        /// <summary>
        /// Désactive tous les éléments de flow quand on clic sur le toggle flow
        /// </summary>
        public void FlowClick()
        {
            foreach (var toggle in flow.GetComponentsInChildren<Toggle>())
            {
                if (toggle.name != "FlowToggle")
                    toggle.isOn = flow.isOn;
            }
        }
        
        /// <summary>
        /// Désactive tous les éléments de l'auto efficacité quand on clic sur le toggle auto efficacité
        /// </summary>
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
