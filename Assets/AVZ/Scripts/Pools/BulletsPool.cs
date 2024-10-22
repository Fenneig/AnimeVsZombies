using AVZ.Factories;
using AVZ.Weapon;
using Unity.Mathematics;
using UnityEngine;

namespace AVZ.Pools
{
    public class BulletsPool : AbstractPool<Bullet>
    {
        public BulletsPool(BulletFactory bulletFactory) : base(bulletFactory)
        {}
        
        public Bullet Create(Vector3 position)
        {
            Bullet bullet = base.Create(position);

            bullet.transform.position = position;
            bullet.transform.rotation = quaternion.identity;
            bullet.gameObject.SetActive(true);
            bullet.OnSurfaceReached += Release;

            return bullet;
        }
        
        public void Release(Bullet bullet)
        {
            bullet.OnSurfaceReached -= Release;
            bullet.Trail.Clear();
            bullet.gameObject.SetActive(false); 
            base.Release(bullet);
        }
    }
}
