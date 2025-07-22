using System;

using UnityEngine;

using ZL.CS.Pooling;

namespace ZL.Unity.Pooling
{
    [Serializable]

    public class ObjectPool : ObjectPool<PooledObject> { }

    [Serializable]

    public class ObjectPool<TPooledObject> : Pool<TPooledObject>

        where TPooledObject : PooledObject
    {
        [Essential]

        [UsingCustomProperty]

        [SerializeField]

        protected TPooledObject prefab = null;

        public TPooledObject Prefab
        {
            get => prefab;
        }

        [SerializeField]

        private Transform parent = null;

        public Transform Parent
        {
            get => parent;
        }

        public override TPooledObject Instantiate()
        {
            return PooledObject.Instantiate(this);
        }
    }
}