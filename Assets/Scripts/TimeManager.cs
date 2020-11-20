using UnityEngine;
using System;
using System.Collections;
using  UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Singleton
    public static TimeManager instance;

    // ---- Chronomètre
    // Texte affiché à l'écran
    public Text timeCounter;

    // Permet de formater directement le temps
    private TimeSpan timePlaying;

    // Chronomètre en marche
    private bool timerGoing;

    // Temps écoulé
    private float elapsedTime;
    // ----
    
    // ---- SlowMotion
    // Intensité du ralentissement
    public float slowdownFactor;
    
    // Durée du ralentissement
    public float slowdownLength;
    // ----
    
    private void Awake()
    {
        // Initialisation du singleton
        if (instance == null)
        {
            instance = this;   
        }
    }

    void Update()
    {
        //Si le jeu est en pause la commande n'est pas exécutée
        if (!PauseMenu.GamePaused)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        }

        // Permet de ne pas accélerer le temps plus que la valeur normale
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        
        Time.fixedDeltaTime += (1f / slowdownLength) * 0.00005f;
        Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0f, 0.02f);
    }
    
    // Crée un effet de ralentissement
    public void DoSlowmotion()
    {
        // timeScale représente vitesse du temps qui passe, = 1 par défaut
        Time.timeScale = slowdownFactor;
        // necessaire d'adapter fixedDeltaTime pour éviter un effet de saccade
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void BeginTimer()
    {
        // Lance le chronomètre
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        // Arrête le timer
        timerGoing = false;
    }

    // Une coroutine ne dépend pas des frames et continuera son execution même si l'on passe à la prochaine frame
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;

            // Convertit le temps écoulé en TimeSpan (pour une meilleure précision)
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            
            timeCounter.text = timePlaying.ToString("mm':'ss'.'ff");

            // Reprend l'execution ici à la frame suivante
            yield return null;
        }
    }
}