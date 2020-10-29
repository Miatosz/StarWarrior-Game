using UnityEngine.UI;
using UnityEngine;

namespace Core
{
    public class Level : MonoBehaviour
    {
        public Transform player;
        public Text levelText;
    
        private void Update()
        {
            string level = Player.Level.ToString();
        
            levelText.text = level;

        }
    }
}

