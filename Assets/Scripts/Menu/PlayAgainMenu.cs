using System;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class PlayAgainMenu : MonoBehaviour
    {
        
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

        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}