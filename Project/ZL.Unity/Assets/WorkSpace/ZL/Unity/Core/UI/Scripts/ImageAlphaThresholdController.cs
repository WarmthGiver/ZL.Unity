using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Image Alpha Threshold Controller")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Image))]

    public sealed class ImageAlphaThresholdController : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]
        
        [GetComponent]

        private Image image;

        [Space]

        [SerializeField]
        
        [Range(0f, 1f)]

        private float alphaThreshold = 0.5f;

        private void Awake()
        {
            image.alphaHitTestMinimumThreshold = alphaThreshold;
        }

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                image.alphaHitTestMinimumThreshold = alphaThreshold;
            }
        }

#if UNITY_EDITOR

        private void Update()
        {
            alphaThreshold = image.alphaHitTestMinimumThreshold;
        }

#endif
    }
}