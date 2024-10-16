using AVZ.Weapon;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class BulletFactory : Factory<Bullet>
    {
        public BulletFactory(DiContainer diContainer, Bullet prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }
    }
}
