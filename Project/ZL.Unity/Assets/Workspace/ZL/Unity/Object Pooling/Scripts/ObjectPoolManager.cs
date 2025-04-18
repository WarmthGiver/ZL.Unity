using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Object Pool Manager")]

    [DefaultExecutionOrder(-1)]

    public abstract class ObjectPoolManager : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private ObjectPool<Component> pool;

        public virtual TComponent Clone<TComponent>()

            where TComponent : Component
        {
            return (TComponent)pool.Generate();
        }
    }
}