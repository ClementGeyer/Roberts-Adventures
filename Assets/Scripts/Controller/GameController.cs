using UnityEngine;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        public void Start()
        {
            // Provisoire
            BeginGame();
        }
    
        // Démarre la partie
        public void BeginGame()
        {
            // Lance le chronomètre
            TimeManager.instance.BeginTimer();
        }
    }
}
