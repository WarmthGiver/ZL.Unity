using UnityEngine;

namespace ZL.Unity.Demo.MeshedSectorDetectorDemo
{
    [AddComponentMenu("")]

    public sealed class DemoEnemy : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private SectorDetector sectorDetector = null;

        [Space]

        [SerializeField]

        private Transform detectionTarget = null;

        private void Update()
        {
            if (sectorDetector.Detect(detectionTarget, out _))
            {
                Debug.Log("Player Detected");
            }
        }
    }
}