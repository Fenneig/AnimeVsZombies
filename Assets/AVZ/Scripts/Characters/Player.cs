using System.Collections.Generic;
using AVZ.Interfaces;
using AVZ.Pools;
using AVZ.Weapon;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace AVZ.Characters
{
    public class Player : MonoBehaviour, IHaveTransform, IDamageable, IHaveSide
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private List<Transform> _spawnPositions;

        private Movement _movement;
        private CinemachineCamera _camera;
        private VisualPool _visualPool;
        private List<Gun> _visuals = new List<Gun>();

        [Inject]
        private void Construct(CinemachineCamera cinemachineCamera, VisualPool visualFactory)
        {
            _camera = cinemachineCamera;
            _visualPool = visualFactory;
        } 

        public Transform Transform => transform;

        public Side Side => Side.Anime;

        public void Hit() =>
            RemoveCharacters(1);

        public void AddCharacters(int amount)
        {
            if (_visuals.Count >= _spawnPositions.Count)
                return;

            if (_visuals.Count + amount >= _spawnPositions.Count)
                amount = _spawnPositions.Count - _visuals.Count;

            for (int i = 0; i < amount; i++)
            {
                Gun visual = _visualPool.Create(_spawnPositions[_visuals.Count].position);
                visual.transform.SetParent(_spawnPositions[_visuals.Count].transform);
                visual.transform.localPosition = Vector3.zero;
                _visuals.Add(visual);
            }
        }

        public void RemoveCharacters(int amount)
        {
            if (amount > _visuals.Count) 
                amount = _visuals.Count;
            
            for (int i = 0; i < amount; i++)
            {
                Gun visualToRemove = _visuals[^1];
                _visuals.Remove(visualToRemove);
                _visualPool.Release(visualToRemove);
            }
        }
        
        private void FixedUpdate()
        {
            _movement.SetDirectionX(0);
            
            if (Input.GetKey(KeyCode.A))
                _movement.SetDirectionX(-1);
            
            if (Input.GetKey(KeyCode.D))
                _movement.SetDirectionX(1);
            
            _movement.Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPickable pickable))
                pickable.PickUp();
        }

        private void Awake()
        {
            _movement = new Movement(_rigidbody, transform, _speed);
            _camera.Follow = transform;
            AddCharacters(1);
        }
        
        private void OnValidate()
        {
            if (_movement != null) 
                _movement.Speed = _speed;
        }
    }
}
