using AVZ.Characters;
using AVZ.Factories;
using AVZ.Weapon;
using UnityEngine;
using Zenject;

namespace AVZ.DI
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Gun _visualPrefab;
        [SerializeField] private GateMovement _gatePrefab;
        [SerializeField] private Zombie _zombiePrefab;
        [SerializeField] private Transform _charactersRootTransform;
        [SerializeField] private Transform _bulletsRootTransform;
        [SerializeField] private Transform _obstacleRootTransform;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletFactory>().FromNew().AsSingle().WithArguments(_bulletPrefab, _bulletsRootTransform);
            Container.Bind<PlayerFactory>().FromNew().AsSingle().WithArguments(_playerPrefab, _charactersRootTransform);
            Container.Bind<ZombieFactory>().FromNew().AsSingle().WithArguments(_zombiePrefab, _charactersRootTransform);
            Container.Bind<GateFactory>().FromNew().AsSingle().WithArguments(_gatePrefab, _obstacleRootTransform);
            Container.Bind<VisualFactory>().FromNew().AsSingle().WithArguments(_visualPrefab);
        }
    }
}
