using AVZ.Factories;
using AVZ.Weapon;
using UnityEngine;

namespace AVZ.Pools
{
    public class VisualPool : AbstractPool<Gun>
    {
        public VisualPool(VisualFactory factory) : base(factory)
        {
        }
        
        public override Gun Create(Vector3 position)
        {
            Gun visual = base.Create(position);
            visual.gameObject.SetActive(true);
            return visual;
        }

        public override void Release(Gun visual)
        {
            visual.gameObject.SetActive(false);
            visual.transform.SetParent(null);
            base.Release(visual);
        }
    }
}
