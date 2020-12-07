using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    // unique instance de la classe
    public static ProgressBar instance;
    
    void Awake(){
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
    }

    // Met à jour la barre de progression
    public void IncrementProgress(float newProgress)
    {
        slider.value = newProgress;
    }
}
