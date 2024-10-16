using UnityEngine;

namespace AVZ.Characters
{
    public class Movement
    {
        private CharacterController _controller;
        private float _speed;
        private float _direction;

        public Movement(CharacterController controller, float speed)
        {
            _controller = controller;
            _speed = speed;
        }
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        
        public float Direction
        {
            get => _direction;
            set => _direction = value;
        }
        
        public void Move() => 
            _controller.Move(Vector3.right * _direction * Time.deltaTime * _speed);
    }
}
