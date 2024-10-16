using System.Collections.Generic;
using AVZ.Factories;
using AVZ.Weapon;
using UnityEngine;

namespace AVZ.Pools
{
    public class BulletsPool
    {
        private BulletFactory _bulletFactory;

        private Queue<Bullet> _availableBullets;

        public BulletsPool(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _availableBullets = new Queue<Bullet>();
        }
        
        public Bullet Create(Vector3 position)
        {
            if (_availableBullets.TryDequeue(out Bullet bullet))
            {
                bullet.transform.position = position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.gameObject.SetActive(true);
                return bullet;
            }

            //??
            Bullet newBullet = _bulletFactory.Get(position, Quaternion.identity);
            newBullet.OnSurfaceReached += () => Release(newBullet);
            //??
            return bullet;
        }
        
        public void Release(Bullet bullet)
        {
            bullet.Trail.Clear();
            bullet.gameObject.SetActive(false);
            _availableBullets.Enqueue(bullet);
        }
    }
}
