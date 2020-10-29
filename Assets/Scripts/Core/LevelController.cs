using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class LevelController : MonoBehaviour
    {

    
        private GameObject[] enemies;
        private GameObject enemyPrefab;
        private int currentLevel = 0;


    

        private void Update()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                SceneManager.LoadScene(++currentLevel);
            }
            //if (GameObject.Find("Enemy"+) == null)

            //{
            //    Player.Level++;
            //    SceneManager.LoadScene("Level" + Player.Level);
            // }
        }

    
    }
}

