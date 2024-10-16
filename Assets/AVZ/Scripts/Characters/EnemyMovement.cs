using UnityEngine;

namespace AVZ.Characters
{
    public class EnemyMovement : MonoBehaviour, IDamageable
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private Transform _target;
        public Side Side => Side.Zombies;

        private void Update()
        {
            if (_target != null)
            {
                Vector3 direction = _target.transform.position - transform.position;

                Quaternion targetQuaternion = Quaternion.LookRotation(direction);

                _transform.rotation = Quaternion.Slerp(targetQuaternion, _transform.rotation, Time.deltaTime * _rotationSpeed);
            }

            _controller.Move(_transform.forward * Time.deltaTime * _speed);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHaveTransform target))
                _target = target.Transform;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                if (target.Side != Side.Anime) 
                    return;
                
                target.Hit();
            }
        }
        
        
        public void Hit()
        {
            Destroy(gameObject);
        }
    }
}
