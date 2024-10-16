using AVZ.Characters;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class EnemyFactory : Factory<EnemyMovement>
    {
        public EnemyFactory(DiContainer diContainer, EnemyMovement prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }
    }
}
