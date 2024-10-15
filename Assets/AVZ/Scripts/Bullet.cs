using UnityEngine;

namespace AVZ
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update() => 
            transform.position += Vector3.forward * Time.deltaTime * _speed;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable target))
            {
                if (target.Side != Side.Zombies) 
                    return;
                
                target.Hit();
                Destroy(gameObject);
            }
            
        }
    }
}
