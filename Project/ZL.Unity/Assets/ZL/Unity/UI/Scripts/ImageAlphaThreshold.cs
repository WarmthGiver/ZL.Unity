using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(Image))]

    public sealed class ImageAlphaThreshold : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private Image image;

        [Space]

        [SerializeField, Range(0f, 1f)]

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
    }
}