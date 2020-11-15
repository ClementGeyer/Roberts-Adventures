using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Intensité du ralentissement
    public float slowdownFactor = 0.1f;
    // Durée du ralentissement
    public float slowdownLength = 12f;

    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        
        // Permet de ne pas accélerer le temps plus que la valeur normale
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    
    // Crée un effet de ralentissement
    public void DoSlowmotion()
    {
        // timeScale représente vitesse du temps qui passe, = 1 par défaut
        Time.timeScale = slowdownFactor;
        // necessaire d'adapter fixedDeltaTime pour éviter un effet de saccade
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}