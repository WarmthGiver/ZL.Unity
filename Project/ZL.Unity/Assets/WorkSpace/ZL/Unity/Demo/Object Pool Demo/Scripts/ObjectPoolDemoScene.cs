#pragma warning disable

using System.Collections;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.Pooling;

namespace ZL.Unity.Demo.ObjectPoolingDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class ObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private ObjectPool<Rigidbody>[] pool;

        [Space]

        [SerializeField]

        private float generateInterval = 0f;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return WaitFor.Seconds(generateInterval);

                var clone = pool[Random.Range(0, pool.Length)].Generate();

                clone.transform.position = transform.position;

                clone.velocity = Vector3.zero;

                clone.SetActive(true);
            }
        }
    }
}