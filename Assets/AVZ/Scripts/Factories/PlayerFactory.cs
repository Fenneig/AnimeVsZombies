using AVZ.Characters;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class PlayerFactory : Factory<Player>
    {
        public PlayerFactory(DiContainer diContainer, Player prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }

        public override Player Get(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Player player = base.Get(position, rotation, parent);

            DiContainer.Bind<Player>().FromInstance(player).AsSingle();
            
            return player;
        }
    }
}
