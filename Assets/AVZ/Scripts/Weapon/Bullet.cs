using System;
using AVZ.Interfaces;
using UnityEngine;

namespace AVZ.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private TrailRenderer _trail;
        public TrailRenderer Trail => _trail;
        public event Action OnSurfaceReached; 

        private void Update() => 
            transform.position += Vector3.forward * Time.deltaTime * _speed;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out IDamageable target))
                return;

            if (other.gameObject.TryGetComponent(out IHaveSide targetSide))
                if (targetSide.Side != Side.Zombies)
                    return;

            target.Hit();
            OnSurfaceReached?.Invoke();
        }
    }
}
