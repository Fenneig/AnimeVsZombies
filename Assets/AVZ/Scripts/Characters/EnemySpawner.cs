using System;
using AVZ.Factories;
using AVZ.Utils;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace AVZ.Characters
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _upperLeftCorner;
        [SerializeField] private Transform _bottomRightCorner;
        [SerializeField] private float _spawnTime;
        [SerializeField] private float _minAmount;
        [SerializeField] private float _maxAmount;

        private const float POSITION_Y = 2.580005f;
        private Timer _timer;
        private EnemyFactory _enemyFactory;

        [Inject]
        private void Construct(EnemyFactory enemyFactory) =>
            _enemyFactory = enemyFactory;

        private void Start()
        {
            _timer = new Timer(_spawnTime);
            _timer.Reset();
            SpawnEnemies();
        }
        
        private void SpawnEnemies()
        {
            int enemiesToSpawn = (int) Random.Range(_minAmount, _maxAmount);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                float positionX = Random.Range(_upperLeftCorner.transform.position.x, _bottomRightCorner.transform.position.x);
                float positionZ = Random.Range(_upperLeftCorner.position.z, _bottomRightCorner.position.z);
                Vector3 newPosition = new Vector3(positionX, POSITION_Y, positionZ);

                _enemyFactory.Get(newPosition, new Quaternion(0, 180, 0, 0));
            }
        }

        private void Update()
        {
            if (_timer.IsReady)
            {
                _timer.Reset();
                SpawnEnemies();
            }
        }
    }
}
