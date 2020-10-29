using UnityEngine;

namespace Enemies
{
    public class EnemyBlast : MonoBehaviour
    {
        public float speed = 5f;
        public Rigidbody2D rb;
        public GameObject go;
    
    
        private void Start()
        {
            //rb.velocity = -(transform.up * speed);
            rb.velocity = -transform.up * speed;
        }

    }
}

