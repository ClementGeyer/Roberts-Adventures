using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audio;
    
    public void backArrow()
    {
        SceneManager.LoadScene(0);
    }

    public void setVolume(float volume)
    {
        audio.SetFloat("Volume", volume);
    }
}
