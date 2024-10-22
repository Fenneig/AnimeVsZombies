using System;
using AVZ.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace AVZ.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private TrailRenderer _trail;
        [FormerlySerializedAs("_enemyLayer")] [SerializeField] private LayerMask _collidingLayers;
        private RaycastHit[] _result = new RaycastHit[1];
        public TrailRenderer Trail => _trail;
        public event Action<Bullet> OnSurfaceReached; 
        

        private void FixedUpdate()
        {
            float stepDistance = Time.fixedDeltaTime * _speed;
            transform.position += Vector3.forward * stepDistance;

            Ray ray = new Ray(transform.position, transform.forward);

            Physics.RaycastNonAlloc(ray, _result, stepDistance, _collidingLayers);

            if (_result[0].collider == null)
                return;
            
            if (_result[0].collider.gameObject.TryGetComponent(out IDamageable target))
            {
                target.Hit();
                _result[0] = default;
            }
            
            OnSurfaceReached?.Invoke(this);
        }
    }
}
