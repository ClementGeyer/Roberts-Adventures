using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class Score : MonoBehaviour
    {
        public Transform player;
        public Text scoreText;

        void Update()
        {
            scoreText.text = (player.position.x*10).ToString("0");
        }
    }
}