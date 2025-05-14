using System;

using UnityEngine;

using ZL.CS.Pooling;

namespace ZL.Unity.Pooling
{
    [Serializable]

    public class ObjectPool<TComponent> : Pool<TComponent>

        where TComponent : Component
    {
        [SerializeField]

        protected TComponent original = null;

        public TComponent Original
        {
            get => original;
        }

        [SerializeField]

        private Transform parent = null;

        public Transform Parent
        {
            get => parent;
        }

        public override TComponent Replicate()
        {
            return PooledObject.Replicate(this);
        }
    }
}