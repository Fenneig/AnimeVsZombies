using AVZ.Interfaces;
using UnityEngine;

namespace AVZ.Characters
{
    public class Zombie : MonoBehaviour, IDamageable, IHaveSide
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private Transform _target;
        public Side Side => Side.Zombies;

        public void SetTarget(Transform target)
        {
            if (_target == null)
                _target = target;
        }
        
        public void Hit()
        {
            Destroy(gameObject);
        }
        
        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 direction = _target.transform.position - transform.position;

                Quaternion targetQuaternion = Quaternion.LookRotation(direction);

                _rigidbody.MoveRotation(Quaternion.Slerp(_transform.rotation, targetQuaternion, Time.fixedDeltaTime * _rotationSpeed));
            }

            _rigidbody.MovePosition(_transform.position + _transform.forward * Time.fixedDeltaTime * _speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out IDamageable target))
                return;
            
            if (collision.gameObject.TryGetComponent(out IHaveSide targetSide))
                if (targetSide.Side != Side.Anime)
                    return;

            target.Hit();
        }
    }
}
