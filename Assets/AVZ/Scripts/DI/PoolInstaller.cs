using AVZ.Pools;
using Zenject;

namespace AVZ.DI
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BulletsPool>().FromNew().AsSingle();
            Container.Bind<ZombiePool>().FromNew().AsSingle();
            Container.Bind<VisualPool>().FromNew().AsSingle();
        }
    }
}
