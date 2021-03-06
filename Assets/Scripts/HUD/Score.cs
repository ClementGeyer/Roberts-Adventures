﻿using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class Score : MonoBehaviour
    {
        public Transform player;
        public Text scoreText;
        public static int score;

        private int buffPos;
 
        private void Start()
        {
            score = 0;
        }

        /// <summary>
        /// Ajoute le paramètre p_score au score
        /// </summary>
        /// <param name="p_score"></param>
        public void addToScore(int p_score){
            score += p_score;
        }

        
        void Update()
        {
            
            if(buffPos < (int)player.position.x){
                score +=   ((int)player.position.x - buffPos) * 10;
                scoreText.text = ""  + score;

                buffPos = (int)player.position.x;
            }
            
        }
    }
}