#pragma warning disable

using System.Collections;

using UnityEngine;

namespace ZL.Unity.Demo.ObjectPoolingDemo
{
    [AddComponentMenu("")]

    public sealed class ObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [Min(0f)]

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