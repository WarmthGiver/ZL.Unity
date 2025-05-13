using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.Pooling;

using ZL.Unity.Singleton;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Pool Manager (Audio Source)")]

    public sealed class AudioSourcePoolManager : PoolManager<AudioSource>
    {

    }

    public abstract class PoolManager<TComponent> : MonoSingleton<PoolManager<TComponent>>

        where TComponent : Component
    {
        [Space]

        [SerializeField]

        private SerializableDictionary<string, ObjectPool<TComponent>> poolDictionary;

        public TComponent Generate(string key, Transform transform)
        {
            return poolDictionary[key].Generate(transform);
        }

        public TComponent Generate(string key)
        {
            return poolDictionary[key].Generate();
        }
    }
}