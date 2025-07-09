using UnityEngine;

using UnityEngine.Animations;

using ZL.Unity.Collections;

using ZL.Unity.Singleton;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Object Pool Manager (Singleton)")]

    public sealed class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        [Space]

        [SerializeField]

        private SerializableDictionary<string, HashSetObjectPool> poolDictionary = null;

        public TClone Clone<TClone>(string key)

            where TClone : PooledObject
        {
            return (TClone)Clone(key);
        }

        public PooledObject Clone(string key)
        {
            return poolDictionary[key].Clone();
        }

        public void CollectAll()
        {
            foreach (var pool in poolDictionary.Values)
            {
                pool.CollectAll();
            }
        }

        public Transform FindClosestObject(Transform from, string targetObjectName, Axis ignoreAxes, float minDistance = float.MaxValue)
        {
            return from.FindClosest(poolDictionary[targetObjectName].Clones, ignoreAxes, minDistance);
        }
    }
}