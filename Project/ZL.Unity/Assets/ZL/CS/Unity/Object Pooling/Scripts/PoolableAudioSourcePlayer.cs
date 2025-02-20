using UnityEngine;

namespace ZL.CS.Unity.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pooling/Audio Source (Poolable) Player")]

    public sealed class PoolableAudioSourcePlayer : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private GameObjectPool<PoolableAudioSource> pool;

        public void Play()
        {
            pool.Generate().SetActive(true);
        }
    }
}