using Controller;
using UnityEngine;

namespace Bonuses
{
    public class SlowMotionBonus : Bonus
    {
        // Gestionnaire de temps
        public TimeManager timeManager;
        
        /// <summary>
        /// Lorsqu'un objet entre en collision avec le bonus
        /// </summary>
        /// <param name="other"></param>
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            // Verifie que l'objet entrant en collision est bien le joueur
            if (other.CompareTag("Player"))
            {
                timeManager.DoSlowmotion();
            }
        }
    }
}