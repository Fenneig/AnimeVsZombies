using UnityEngine;

namespace AVZ
{
    public class PlayerTriggerZone : MonoBehaviour, IHaveTransform
    {
        [SerializeField] private Player _player;
        public Transform Transform => _player.Transform;
    }
}
