using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class PlayerName : MonoBehaviour
    {
        public GameObject playerNameUI;
        public InputField inputName;
        public static string playerName;
        
        /// <summary>
        /// Quand on clique sur le bouton on récupère la valeur du nom du joueur
        /// </summary>
        public void clic()
        {
            // On accepte pas le clic si le joueur ne rempli rien
            if (inputName.text != "")
            {
                playerName = inputName.text;
                Debug.Log(playerName);
                playerNameUI.SetActive(false);
            }
        }
    }
}

