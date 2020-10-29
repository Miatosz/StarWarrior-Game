using System.Collections;
using Core;
using UnityEngine;

namespace Controller
{
    public class ShipController : MonoBehaviour
    {
        public float shipHorizontalSpeed = 10f;
        private Vector3 _shipPosition;
        private Vector3 _startPosition = new Vector3(0, -5, -1);
        
        public GameObject explosion;
        public GameObject ship;
        
        
    
        private void Start()
        {
            _shipPosition = gameObject.transform.position;
        }
    
        private void Update()
        {
           
            _shipPosition.x += Input.GetAxis("Horizontal") * shipHorizontalSpeed * Time.deltaTime;
            _shipPosition.x = Mathf.Clamp(_shipPosition.x, -7.38f, 7.36f);
            gameObject.transform.position = _shipPosition;
    
            
        }
    
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.tag == "EnemyBullet")
            {
                Debug.Log(Player.Lifes);
                Player.Lifes--;
                
                //dead
                Instantiate(explosion, transform.position, Quaternion.identity);
                StartCoroutine(Dead());
    
    
                
                
                if (Player.Lifes == 0)
                {
                    //endgame
                }
                
            }
        }
    
        private IEnumerator Dead()
        {
            ship.GetComponent<Renderer>().enabled = false;
            ship.GetComponent<PolygonCollider2D>().enabled = false;
            
            yield return new WaitForSeconds(3);
            Respawn();
            }
    
        private void Respawn()
        {
            _shipPosition = new Vector3(0, -5, -1);
            ship.GetComponent<Renderer>().enabled = true;
            ship.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

}
