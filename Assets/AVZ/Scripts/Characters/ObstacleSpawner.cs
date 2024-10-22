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
        [SerializeField] private Transform[] _gatePoints;
        [SerializeField] private float _spawnTime;
        [SerializeField, Range(0, 100)] private float _buffSpawnChance = 20f;
        [SerializeField] private float _minAmount;
        [SerializeField] private float _maxAmount;

        private const float POSITION_Y = 2.580005f;
        private Timer _timer;
        private ZombiePool _zombiePool;
        private GateFactory _gateFactory;
        private Quaternion _oppositeCreatureLook = new Quaternion(0, 180, 0, 0);

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
        }
        
        private void SpawnEnemies()
        {
            int enemiesToSpawn = (int) Random.Range(_minAmount, _maxAmount);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                float positionX = Random.Range(_upperLeftCorner.transform.position.x, _bottomRightCorner.transform.position.x);
                float positionZ = Random.Range(_upperLeftCorner.position.z, _bottomRightCorner.position.z);
                Vector3 newPosition = new Vector3(positionX, POSITION_Y, positionZ);

                _zombiePool.Create(newPosition, _oppositeCreatureLook);
            }
        }

        private void SpawnGate()
        {
            int gatesToSpawnAmount = Random.Range(1, 4);
            if (gatesToSpawnAmount < 3)
            {
                bool[] spawnPositionOccupied = new bool[3];

                for (int i = 0; i < gatesToSpawnAmount; i++)
                {
                    int randomPosition = PickRandomPosition(spawnPositionOccupied);
                    spawnPositionOccupied[randomPosition] = true;
                    Vector3 createPosition = _gatePoints[randomPosition].position;
                    var gate = _gateFactory.Get(createPosition, _oppositeCreatureLook);
                    gate.name = $"gate - {randomPosition}";
                }
            }
            else
            {
                for (int i = 0; i < _gatePoints.Length; i++)
                {
                    _gateFactory.Get(_gatePoints[i].position, _oppositeCreatureLook);
                }
            }
        }
        
        private int PickRandomPosition(bool[] spawnPositionOccupied)
        {
            int randomPosition;

            do randomPosition = Random.Range(0, spawnPositionOccupied.Length);
            while (spawnPositionOccupied[randomPosition]);

            return randomPosition;
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
