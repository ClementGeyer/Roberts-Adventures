using System;
using System.Collections;
using Menu;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
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
    
        /// <summary>
        /// Initialise le singleton
        /// </summary>
        private void Awake()
        {
            // Initialisation du singleton
            if (instance == null)
            {
                instance = this;   
            }
        }

        /// <summary>
        /// Fait revenir le temps à la normale petit à petit
        /// </summary>
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
        
        /// <summary>
        /// Crée un effet de ralentissement
        /// </summary>
        public void DoSlowmotion()
        {
            // timeScale représente vitesse du temps qui passe, = 1 par défaut
            Time.timeScale = slowdownFactor;
            // necessaire d'adapter fixedDeltaTime pour éviter un effet de saccade
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }

        /// <summary>
        /// Lance le chronomètre
        /// </summary>
        public void BeginTimer()
        {
            timerGoing = true;
            elapsedTime = 0f;

            StartCoroutine(UpdateTimer());
        }

        /// <summary>
        /// Stop le chronomètre
        /// </summary>
        public void EndTimer()
        {
            // Arrête le timer
            timerGoing = false;
        }
        
        /// <summary>
        /// Met à jour le timer
        /// Une coroutine ne dépend pas des frames et continuera son execution même si l'on passe à la prochaine frame
        /// </summary>
        /// <returns>null</returns>
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
}