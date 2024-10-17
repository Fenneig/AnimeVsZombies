using AVZ.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace AVZ.Characters
{
    public class GateMovement : MonoBehaviour, IPickable
    {
        [Header("Settings")]
        [SerializeField] private float _speed;
        [Header("Visual")]
        [SerializeField] private Material _badMaterial;
        [SerializeField] private Material _goodMaterial;
        [SerializeField] private MeshRenderer _mainGate;
        [SerializeField] private TMP_Text _amount;
        private int _value;
        private BuffResolver _buffResolver;

        [Inject]
        private void Construct(BuffResolver buffResolver) => 
            _buffResolver = buffResolver;

        private void Start()
        {
            int amount = Random.Range(1, 5);
            _value = amount;
            _amount.text = amount > 0 ? $"+{amount}" : $"{amount}";
            _mainGate.material = amount > 0 ? _goodMaterial : _badMaterial;
        }

        private void Update() => 
            transform.position -= Vector3.forward * Time.deltaTime * _speed;
        
        public void PickUp()
        {
            _buffResolver.Resolve(BuffType.CharactersAmount, _value);
            Destroy(gameObject);
        }
    }

}
