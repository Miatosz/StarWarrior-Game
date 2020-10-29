using Enemies;
using UnityEngine;


namespace Core
{
    public class Bullet : MonoBehaviour
    {
        public GameObject explosion;

        public float speed = 20f;
        public Rigidbody2D rb;
        public GameObject go;
    
    
        private void Start()
        {
            rb.velocity = transform.up * speed;
        }

        void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Debug.Log(hitInfo.tag);
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            if (hitInfo.tag == "Boss")
            {
                //Instantiate(explosion, transform.position, Quaternion.identity);
            }
        
            if (enemy != null)
            {
                enemy.TakeDamage(100);
                Destroy(gameObject);
            }

            if (hitInfo.gameObject.CompareTag("Boss"))
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Debug.Log("boom");
            }
        }
    
    
    }

}
