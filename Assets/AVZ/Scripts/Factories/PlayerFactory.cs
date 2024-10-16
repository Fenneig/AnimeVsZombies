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
    }
}
