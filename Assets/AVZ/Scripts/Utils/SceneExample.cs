using AVZ.Factories;
using UnityEngine;
using Zenject;

namespace AVZ.Utils
{
    public class SceneExample : MonoBehaviour
    {
        [SerializeField] private Transform _playerAppearTransform;
        [SerializeField] private Transform _charactersRoot;
        private PlayerFactory _playerFactory;

        [Inject]
        private void Construct(PlayerFactory playerFactory) => _playerFactory = playerFactory;

        private void Awake() => 
            _playerFactory.Get(_playerAppearTransform.position, Quaternion.identity, _charactersRoot);
    }
}
