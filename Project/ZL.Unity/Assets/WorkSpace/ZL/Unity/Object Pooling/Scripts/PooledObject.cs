using System;

using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Pooled Object")]

    [DisallowMultipleComponent]

    public class PooledObject : MonoBehaviour
    {
        private Action onDisableAction = null;

        private Action onDestroyAction = null;

        public static TReplica Replicate<TReplica>(ObjectPool<TReplica> pool)

            where TReplica : Component
        {
            var replica = Instantiate(pool.Original, pool.Parent);

            if (replica.TryGetComponent<PooledObject>(out var pooledObject) == false)
            {
                FixedDebug.LogWarning($"The '{pool.Original.name}' prefab being pooled doesn't have a component of type 'PooledObject'. We recommend adding it to the prefab to improve performance.");

                pooledObject = replica.AddComponent<PooledObject>();
            }

            pooledObject.onDisableAction = () => pool.Collect(replica);

            pooledObject.onDestroyAction = () => pool.Release(replica);

            return replica;
        }

        private void OnDisable()
        {
            onDisableAction?.Invoke();
        }

        private void OnDestroy()
        {
            onDestroyAction?.Invoke();
        }
    }
}