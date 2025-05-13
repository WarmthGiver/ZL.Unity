#pragma warning disable

using System.Collections;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.Coroutines;

using ZL.Unity.Pooling;

namespace ZL.Unity.Demo.ObjectPoolingDemo
{
    [AddComponentMenu("")]

    public sealed class ObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private ObjectPool<Transform>[] pool;

        [Space]

        [SerializeField]

        private float generateInterval = 0f;

        private IEnumerator Start()
        {
            while (true)
            {
                var replica = pool[Random.Range(0, pool.Length)].Generate();

                replica.SetActive(true);

                yield return WaitForSecondsCache.Get(generateInterval);
            }
        }
    }
}