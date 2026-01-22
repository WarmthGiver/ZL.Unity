using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Pooling/Object Pool Manager (Singleton)")]

    public sealed class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        [Space]

        [SerializeField]

        private SerializableDictionary<string, HashSetObjectPool> poolDictionary = null;

        public TPooledObject Clone<TPooledObject>(string key)

            where TPooledObject : PooledObject
        {
            return (TPooledObject)Clone(key);
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

        public PooledObject FindClosest(Transform from, string targetObjectName, Axis ignoreAxes, float minDistance = float.MaxValue)
        {
            return from.FindClosest(poolDictionary[targetObjectName].Clones, ignoreAxes, minDistance);
        }
    }
}