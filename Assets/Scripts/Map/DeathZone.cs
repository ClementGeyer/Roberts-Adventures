﻿using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Verifie que l'objet entrant en collision est bien le joueur
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Destruction du joueur");
        }
    }
}
