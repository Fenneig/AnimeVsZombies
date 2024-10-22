using AVZ.Characters;
using AVZ.Factories;
using UnityEngine;

namespace AVZ.Pools
{
    public class ZombiePool : AbstractPool<Zombie>
    {
        public ZombiePool(ZombieFactory factory) : base(factory)
        {
        }

        public Zombie Create(Vector3 position, Quaternion rotation)
        {
            Zombie zombie = base.Create(position);

            zombie.transform.position = position;
            zombie.transform.rotation = rotation;
            zombie.gameObject.SetActive(true);
            
            zombie.OnDie += Release;

            return zombie;
        }

        public override void Release(Zombie zombie)
        {
            zombie.OnDie -= Release;
            zombie.gameObject.SetActive(false);
            base.Release(zombie);
        }
    }
}
