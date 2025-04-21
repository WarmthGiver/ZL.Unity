using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Object Pool Manager")]

    [DefaultExecutionOrder(-1)]

    public abstract class ObjectPoolManager<TComponent> : MonoBehaviour

        where TComponent : Component
    {
        [Space]

        [SerializeField]

        private ObjectPool<TComponent> pool;

        public virtual TComponent Generate()
        {
            return pool.Generate();
        }
    }
}