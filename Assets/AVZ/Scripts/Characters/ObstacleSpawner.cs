using AVZ.Factories;
using AVZ.Pools;
using AVZ.Utils;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace AVZ.Characters
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _upperLeftCorner;
        [SerializeField] private Transform _bottomRightCorner;
        [SerializeField] private float _spawnTime;
        [SerializeField, Range(0, 100)] private float _buffSpawnChance = 20f;
        [SerializeField] private float _minAmount;
        [SerializeField] private float _maxAmount;

        private const float POSITION_Y = 2.580005f;
        private Timer _timer;
        private ZombiePool _zombiePool;
        private GateFactory _gateFactory;

        [Inject]
        private void Construct(ZombiePool zombiePool, GateFactory gateFactory)
        {
            _zombiePool = zombiePool;
            _gateFactory = gateFactory;
        }

        private void Start()
        {
            _timer = new Timer(_spawnTime);
            _timer.Reset();
            SpawnGate();
        }
        
        private void SpawnEnemies()
        {
            int enemiesToSpawn = (int) Random.Range(_minAmount, _maxAmount);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                float positionX = Random.Range(_upperLeftCorner.transform.position.x, _bottomRightCorner.transform.position.x);
                float positionZ = Random.Range(_upperLeftCorner.position.z, _bottomRightCorner.position.z);
                Vector3 newPosition = new Vector3(positionX, POSITION_Y, positionZ);

                _zombiePool.Create(newPosition, new Quaternion(0, 180, 0, 0));
            }
        }

        private void SpawnGate()
        {
            float positionX = Random.Range(_upperLeftCorner.transform.position.x, _bottomRightCorner.transform.position.x);
            float positionZ = Random.Range(_upperLeftCorner.position.z, _bottomRightCorner.position.z);
            Vector3 newPosition = new Vector3(positionX, POSITION_Y, positionZ);

            _gateFactory.Get(newPosition, new Quaternion(0, 180, 0, 0));
        }

        private void Update()
        {
            if (!_timer.IsReady)
                return;
            
            _timer.Reset();
            float chance = Random.Range(0, 100);
            if (chance <= _buffSpawnChance) 
                SpawnGate();
            else
                SpawnEnemies();
        }
    }
}
