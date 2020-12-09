using UnityEngine;

namespace Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        /// <summary>
        /// Lorsqu'un objet entre en collision avec le bonus
        /// </summary>
        /// <param name="other"></param>
        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}