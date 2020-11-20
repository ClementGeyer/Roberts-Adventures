using UnityEngine;

namespace Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        // Lorsqu'un objet entre en collision avec le bonus
        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}