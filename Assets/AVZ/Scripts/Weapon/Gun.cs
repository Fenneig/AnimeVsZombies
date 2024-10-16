using AVZ.Pools;
using AVZ.Utils;
using UnityEngine;
using Zenject;

namespace AVZ.Weapon
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _fireSpot;
        [SerializeField] private float _fireRate;
        private Timer _timer;
        private BulletsPool _bulletsPool;

        [Inject]
        private void Construct(BulletsPool bulletsPool) =>
            _bulletsPool = bulletsPool;

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
            _bulletsPool.Create(_fireSpot.position);
    }
}
