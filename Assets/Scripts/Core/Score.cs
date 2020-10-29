using UnityEngine.UI;
using UnityEngine;

namespace Core
{
    public class Score : MonoBehaviour
    {
        public Transform player;
        public Text scoreText;
    
        private void Update()
        {
            string score = Player.Score.ToString();
        
            scoreText.text = score;
        }
    }
}

