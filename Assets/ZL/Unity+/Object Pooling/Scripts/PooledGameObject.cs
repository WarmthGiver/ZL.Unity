using UnityEngine;

namespace ZL.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pool/Game Object (Pooled)")]

    public sealed class PooledGameObject : PooledGameObject<PooledGameObject> { }

    [DisallowMultipleComponent]

    public abstract class PooledGameObject<T> : MonoBehaviour

        where T : PooledGameObject<T>
    {
        public GameObjectPool<T> Pool { get; private set; }

        public static T Clone(GameObjectPool<T> pool)
        {
            var clone = Instantiate(pool.Original, pool.Parent);

            clone.Pool = pool;

            return clone;
        }

        protected virtual void OnDisable()
        {
            Pool.Collect((T)this);
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}