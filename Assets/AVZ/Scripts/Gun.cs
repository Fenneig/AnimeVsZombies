using UnityEngine;

namespace AVZ
{
    public class Gun  : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _fireSpot;
        [SerializeField] private float _fireRate;
        private Timer _timer;

        private void Start()
        {
            _timer = new Timer(1 / _fireRate);
            _timer.Reset();
        }

        private void Update()
        {
            if (!_timer.IsReady)
                return;
            
            Fire();
            _timer.Reset();
        }

        private void Fire() => 
            Instantiate(_bulletPrefab, _fireSpot.position, Quaternion.identity);
    }
}
