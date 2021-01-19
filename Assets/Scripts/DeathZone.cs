using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifie que l'objet entrant en collision est bien le joueur
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Destruction du joueur");
        }
    }
}
