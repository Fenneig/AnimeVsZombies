using AVZ.Interfaces;
using UnityEngine;

namespace AVZ.Characters
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private Zombie _zombie;
        
        private void OnTriggerEnter(Collider collision)
        {
            if (!collision.gameObject.TryGetComponent(out IHaveTransform target))
                return;
            
            if (collision.gameObject.TryGetComponent(out IHaveSide targetSide))
                if (targetSide.Side != Side.Anime)
                    return;
            
            _zombie.SetTarget(target.Transform);
        }
    }
}
