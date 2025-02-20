using UnityEngine;

using UnityEngine.UI;

namespace ZL.CS.Unity.UI
{
    [DisallowMultipleComponent]
    
    [RequireComponent(typeof(Image))]

    public sealed class ImageRepeater : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RectTransform rectTransform;

        [SerializeField]

        private float pixelPerSecond = 0f;

        private Vector3 originalPosition;

        private float value = 0f;

        private void FixedUpdate()
        {
            transform.localPosition = originalPosition + Vector3.right * Mathf.Repeat(value, rectTransform.rect.width);

            value += pixelPerSecond * Time.fixedDeltaTime;
        }
    }
}