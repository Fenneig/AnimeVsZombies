using System;
using AVZ.Interfaces;
using UnityEngine;

namespace AVZ.Characters
{
    public class Zombie : MonoBehaviour, IDamageable, IHaveSide
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private Transform _target;
        public Side Side => Side.Zombies;
        public event Action<Zombie> OnDie;

        public void SetTarget(Transform target)
        {
            if (_target == null)
                _target = target;
        }
        
        public void Hit() => 
            OnDie?.Invoke(this);

        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 direction = (_target.transform.position - _transform.position).normalized;
                direction.y = 0;
                
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed * Mathf.Deg2Rad * Time.deltaTime, 0.0f);
        
                transform.rotation = Quaternion.LookRotation(newDirection);
            }

            transform.position = _transform.position + _transform.forward * Time.fixedDeltaTime * _speed;
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
