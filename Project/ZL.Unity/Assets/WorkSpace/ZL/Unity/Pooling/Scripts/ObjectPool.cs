using System;

using UnityEngine;

using ZL.CS.Collections;

using ZL.CS.Pooling;

namespace ZL.Unity.Pooling
{
    [Serializable]

    public class ObjectPool<TComponent> : Pool<TComponent>

        where TComponent : Component
    {
        [SerializeField]

        protected TComponent original;

        public TComponent Original
        {
            get => original;
        }

        [SerializeField]

        private Transform parent;

        public TComponent Generate(Transform parent)
        {
            if (stock.Count != 0)
            {
                return stock.PopLast();
            }

            return Replicate(parent);
        }

        public override TComponent Replicate()
        {
            return Replicate(parent);
        }

        public TComponent Replicate(Transform parent)
        {
            return PooledObject.Replicate(this, parent);
        }
    }
}