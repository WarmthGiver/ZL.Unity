using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pool/Game Object (Pooled)")]

    public sealed class PooledGameObject : PooledGameObject<PooledGameObject> { }

    [DisallowMultipleComponent]

    public abstract class PooledGameObject<T> : MonoBehaviour

        where T : PooledGameObject<T>
    {
        private T @this;

        public GameObjectPool<T> Pool { get; private set; }

        public static T Clone(GameObjectPool<T> pool)
        {
            T clone = Instantiate(pool.Original, pool.Parent);

            clone.@this = clone;

            clone.Pool = pool;

            return clone;
        }

        protected virtual void OnDisable()
        {
            Pool.Collect(@this);
        }
        
        protected virtual void OnDestroy()
        {
            Pool.Remove(@this);
        }
    }
}