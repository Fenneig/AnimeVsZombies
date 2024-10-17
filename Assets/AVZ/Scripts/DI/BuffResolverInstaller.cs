using AVZ.Characters;
using Zenject;

namespace AVZ.DI
{
    public class BuffResolverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BuffResolver>().FromNew().AsSingle();
        }
    }
}
