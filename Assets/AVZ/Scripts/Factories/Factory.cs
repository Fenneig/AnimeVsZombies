using UnityEngine;
using Zenject;

namespace AVZ.Factories
{
    public abstract class Factory<T> where T : Object
    {
        protected DiContainer DiContainer;
        private T _prefab;
        private Transform _parent;

        public Factory(DiContainer diContainer, T prefab, Transform parent = null)
        {
            DiContainer = diContainer;
            _prefab = prefab;
            _parent = parent;
        }

        public virtual T Get(Vector3 position, Quaternion rotation, Transform parent = null) => 
            DiContainer.InstantiatePrefab(_prefab, position, rotation, parent == null ? _parent : parent).GetComponent<T>();
    }
}
