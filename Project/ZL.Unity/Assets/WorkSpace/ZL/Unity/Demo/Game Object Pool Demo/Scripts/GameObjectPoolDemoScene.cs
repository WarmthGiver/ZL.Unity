#pragma warning disable

using System.Collections;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.Pooling;

namespace ZL.Unity.ObjectPoolingDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class GameObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private ObjectPool<Rigidbody>[] pool;

        [Space]

        [SerializeField]

        private float generateSpeed = 0f;

        [Space]

        [SerializeField]

        private Transform spawnPoint;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return WaitFor.Seconds(generateSpeed);

                var clone = pool[Random.Range(0, pool.Length)].Generate();

                clone.transform.position = transform.position;

                clone.velocity = Vector3.zero;

                clone.SetActive(true);
            }
        }
    }
}