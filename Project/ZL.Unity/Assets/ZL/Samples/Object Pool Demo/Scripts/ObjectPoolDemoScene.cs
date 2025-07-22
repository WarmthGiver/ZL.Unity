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

        private float generateInterval = 0f;

        [Space]

        [SerializeField]

        private string[] keys = null;

        private IEnumerator Start()
        {
            while (true)
            {
                var clone = ObjectPoolManager.Instance.Clone(keys[Random.Range(0, keys.Length)]);

                clone.transform.localPosition = Vector3.zero;

                clone.Appear();

                yield return WaitForSecondsCache.Get(generateInterval);
            }
        }
    }
}