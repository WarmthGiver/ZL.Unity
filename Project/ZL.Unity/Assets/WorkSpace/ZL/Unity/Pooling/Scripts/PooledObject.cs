using System;

using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Pooled Object")]

    public class PooledObject : MonoBehaviour
    {
        private Action onDisableAction = null;

        public static TComponent Replicate<TComponent>(ObjectPool<TComponent> pool, Transform parent)

            where TComponent : Component
        {
            var replica = Instantiate(pool.Original, parent);

            if (replica.TryGetComponent<PooledObject>(out var pooledObject) == false)
            {
                FixedDebug.LogWarning($"Prefab '{replica.gameObject.name}' being pooled does not have a component of type 'Pooled Object'. We recommend adding it to the prefab to improve performance.");

                pooledObject = replica.AddComponent<PooledObject>();
            }

            pooledObject.onDisableAction = () => pool.Collect(replica);

            return replica;
        }

        #if UNITY_EDITOR

        private void Start()
        {
            if (onDisableAction == null)
            {
                FixedDebug.LogWarning($"Game Object '{gameObject.name}' is a 'Pooled Object' but was not created from an'Object Pool'.");
            }
        }

        #endif

        private void OnDisable()
        {
            onDisableAction?.Invoke();
        }
    }
}