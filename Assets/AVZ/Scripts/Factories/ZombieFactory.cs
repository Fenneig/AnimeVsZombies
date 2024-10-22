using AVZ.Characters;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class ZombieFactory : Factory<Zombie>
    {
        public ZombieFactory(DiContainer diContainer, Zombie prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }
    }
}
