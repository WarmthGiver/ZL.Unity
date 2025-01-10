using System.Collections;

using UnityEngine;

namespace ZL.Unity.ObjectPooling.Demo
{
    [DisallowMultipleComponent]

    public sealed class GameObjectPoolDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private GameObjectPool<PooledGameObject> gameObjectPool;

        [Space]

        [SerializeField]

        private int preGenerateCount = 10;

        [SerializeField]

        private float generateSpeed = 0.5f;

        [Space]

        [SerializeField]

        private Transform spawnPoint;

        private IEnumerator Start()
        {
            gameObjectPool.PreGenerate(preGenerateCount);

            while (true)
            {
                var pooledGameObject = gameObjectPool.Generate();

                pooledGameObject.transform.localPosition = spawnPoint.transform.localPosition;

                yield return WaitFor.Seconds(generateSpeed);
            }
        }
    }
}