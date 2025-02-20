#pragma warning disable

using System.Collections;

using UnityEngine;

using ZL.CS.Unity.Collections;

namespace ZL.CS.Unity.ObjectPooling.Demo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class GameObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private GameObjectPool<Rigidbody>[] pool;

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