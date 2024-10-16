using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public abstract class Factory<T> where T : Object
    {
        private DiContainer _diContainer;
        private T _prefab;
        private Transform _parent;

        public Factory(DiContainer diContainer, T prefab, Transform parent = null)
        {
            _diContainer = diContainer;
            _prefab = prefab;
            _parent = parent;
        }

        public virtual T Get(Vector3 position, Quaternion rotation, Transform parent = null) => 
            _diContainer.InstantiatePrefab(_prefab, position, rotation, parent == null ? _parent : parent).GetComponent<T>();
    }
}
