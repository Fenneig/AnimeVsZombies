using AVZ.Weapon;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class VisualFactory : Factory<Gun>
    {
        public VisualFactory(DiContainer diContainer, Gun prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }
    }
}
