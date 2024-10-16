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
        [SerializeField] private EnemyMovement _enemyPrefab;
        [SerializeField] private Transform _charactersRootTransform;
        [SerializeField] private Transform _bulletsRootTransform;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletFactory>().FromNew().AsSingle().WithArguments(_bulletPrefab, _bulletsRootTransform);
            Container.Bind<PlayerFactory>().FromNew().AsSingle().WithArguments(_playerPrefab, _charactersRootTransform);
            Container.Bind<EnemyFactory>().FromNew().AsSingle().WithArguments(_enemyPrefab, _charactersRootTransform);
        }
    }
}
