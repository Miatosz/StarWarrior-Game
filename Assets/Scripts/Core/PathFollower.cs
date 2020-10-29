using UnityEngine;

namespace Core
{
    public class PathFollower : MonoBehaviour
    {
        Node[] pathNode;
        public GameObject player;

        public float moveSpeed;
        private float _timer;
        private int _currentNode;

        private static Vector3 _currentPositionHolder;
    
        private void Start()
        {
            pathNode = GetComponentInChildren<Node[]>();
            CheckNode();
        }

        void CheckNode()
        {
            _currentPositionHolder = pathNode[_currentNode].transform.position;
        }

        private void Update()
        {
            _timer += Time.deltaTime * moveSpeed;
        
            if (player.transform.position != _currentPositionHolder)
            {
                player.transform.position = Vector3.Lerp(player.transform.position, _currentPositionHolder, _timer);
            }
            else
            {
                _currentNode++;
                CheckNode();
            }
        }
    }


}
