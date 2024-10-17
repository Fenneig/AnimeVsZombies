using AVZ.Characters;
using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public class GateFactory : Factory<GateMovement>
    {
        public GateFactory(DiContainer diContainer, GateMovement prefab, Transform parent = null) : base(diContainer, prefab, parent)
        {
        }
    }
}
