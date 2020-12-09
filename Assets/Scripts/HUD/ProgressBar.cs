using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    // unique instance de la classe
    public static ProgressBar instance;
    
    /// <summary>
    /// Appelé au démarrage du jeu
    /// Instancie le singleton
    /// </summary>
    void Awake(){
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
    }
    
    /// <summary>
    /// Met à jour la barre de progression
    /// </summary>
    /// <param name="newProgress"></param>
    public void IncrementProgress(float newProgress)
    {
        slider.value = newProgress;
    }
}
