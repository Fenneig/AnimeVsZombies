using System;
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                if (target.Side != Side.Zombies) 
                    return;
                
                target.Hit();
                OnSurfaceReached?.Invoke();
            }
        }
    }
}
