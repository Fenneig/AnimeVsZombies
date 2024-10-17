using UnityEngine;

namespace AVZ.Characters
{
    public class Movement
    {
        private Rigidbody _rigidbody;
        private Transform _transform;
        private float _speed;
        private Vector3 _direction;

        public Movement(Rigidbody rigidbody, Transform transform, float speed)
        {
            _rigidbody = rigidbody;
            _transform = transform;
            _speed = speed;
        }
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public void SetDirectionX(float x) => _direction.x = x;
        public void SetDirectionZ(float z) => _direction.z = z;
        
        public void Move() => 
            _rigidbody.MovePosition(_transform.position + _direction * _speed * Time.fixedDeltaTime);
    }
}
