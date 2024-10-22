using System.Collections.Generic;
using AVZ.Factories;
using Unity.Mathematics;
using UnityEngine;

namespace AVZ.Pools
{
    public class AbstractPool<T> where T : Object
    {
        private Factory<T> _factory;
        private Queue<T> _availableObjects;

        public AbstractPool(Factory<T> factory)
        {
            _factory = factory;
            _availableObjects = new Queue<T>();
        }

        public virtual T Create(Vector3 position) => 
            _availableObjects.TryDequeue(out T objectToCreate) 
                ? objectToCreate 
                : _factory.Get(position, quaternion.identity);

        public virtual void Release(T visual) => 
            _availableObjects.Enqueue(visual);
    }
}
