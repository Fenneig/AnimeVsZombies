using System.Collections.Generic;
using AVZ.Factories;
using AVZ.Interfaces;
using AVZ.Weapon;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace AVZ.Characters
{
    public class Player : MonoBehaviour, IHaveTransform, IDamageable, IHaveSide
    {
        [SerializeField] private GameObject _visualPrefab;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private List<Transform> _spawnPositions;

        private Movement _movement;
        private CinemachineCamera _camera;
        private VisualFactory _visualFactory;
        private List<Gun> _visuals = new List<Gun>();

        [Inject]
        private void Construct(CinemachineCamera cinemachineCamera, VisualFactory visualFactory)
        {
            _camera = cinemachineCamera;
            _visualFactory = visualFactory;
        } 

        public Transform Transform => transform;

        public Side Side => Side.Anime;
        
        public void Hit() => 
            Destroy(gameObject);

        public void AddCharacters(int amount)
        {
            if (_visuals.Count >= _spawnPositions.Count)
                return;

            if (_visuals.Count + amount >= _spawnPositions.Count)
                amount = _spawnPositions.Count - _visuals.Count;

            for (int i = 0; i < amount; i++)
            {
                Gun visual = _visualFactory.Get(_spawnPositions[_visuals.Count].position, Quaternion.identity);
                visual.transform.SetParent(_spawnPositions[_visuals.Count].transform);
                _visuals.Add(visual);
            }
        }

        public void RemoveCharacters(int amount)
        {
            
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
