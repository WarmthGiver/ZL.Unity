#pragma warning disable

using System.Collections;

using UnityEngine;

namespace ZL.Unity.ObjectPooling.Demo
{
    [DisallowMultipleComponent]

    public sealed class GameObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private GameObjectPool<Rigidbody> pool;

        [Space]

        [SerializeField]

        private int preGenerateCount = 0;

        [SerializeField]

        private float generateSpeed = 0f;

        [Space]

        [SerializeField]

        private Transform spawnPoint;

        private IEnumerator Start()
        {
            pool.PreGenerate(preGenerateCount);

            while (true)
            {
                yield return WaitFor.Seconds(generateSpeed);

                var clone = pool.Generate();

                if (spawnPoint != null)
                {
                    clone.transform.localPosition = spawnPoint.transform.localPosition;
                }

                clone.velocity = Vector3.zero;
            }
        }
    }
}