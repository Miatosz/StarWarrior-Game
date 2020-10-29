using UnityEngine;

namespace Core
{
    public class InfiniteScrollBackground : MonoBehaviour
    {
        public float scrollSpeed;
        private Vector2 _offset;

        void Update()
        {
            _offset = new Vector2(0, Time.time * scrollSpeed);
            GetComponent<Renderer>().material.mainTextureOffset = _offset;

        
        }
    }
}

