using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //Cet attribut est le mixer principal de son du jeu
    public AudioMixer audioMixer;
    //Cet attribut est le pannel du préfab "Options"
    public GameObject menu;

    //Cette méthode permet de sortir du menu Options en appuyant sur la flèche
    public void BackArrow()
    {
        menu.SetActive(false);
    }

    //Cette méthode permet de régler le volume du mixer principal en changer le slider dans le menu Options
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        
    }
}
