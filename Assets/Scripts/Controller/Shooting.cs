using UnityEngine;

namespace Controller
{
    public class Shooting : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Debug.Log("Fire");
                Shoot();
            }
        }


        void Shoot()
        {
            // shooting logic
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}

