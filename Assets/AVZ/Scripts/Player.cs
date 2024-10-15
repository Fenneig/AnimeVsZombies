using UnityEngine;

namespace AVZ
{
    public class Player : MonoBehaviour, IHaveTransform, IDamageable
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;
        
        private Movement _movement;

        public Transform Transform => transform;

        public Side Side => Side.Anime;
        
        public void Hit() => 
            Destroy(gameObject);

        private void Update()
        {
            _movement.Direction = 0;
            
            if (Input.GetKey(KeyCode.A))
                _movement.Direction = -1;
            
            if (Input.GetKey(KeyCode.D))
                _movement.Direction = 1;
            
            _movement.Move();
        }


        private void Awake() => 
            _movement = new Movement(_controller, _speed);

        private void OnValidate()
        {
            if (_movement != null) 
                _movement.Speed = _speed;
        }
    }
}
