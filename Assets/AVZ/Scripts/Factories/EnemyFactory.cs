using AVZ.Characters;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class EnemyFactory : Factory<Zombie>
    {
        public EnemyFactory(DiContainer diContainer, Zombie prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }
    }
}
