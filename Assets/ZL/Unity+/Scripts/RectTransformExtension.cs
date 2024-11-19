using UnityEngine;

namespace ZL
{
    public static partial class RectTransformExtension
    {
        public static void LookAt(this RectTransform instance, in Vector2 worldUp)
        {
            instance.localRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(worldUp.y - instance.localPosition.y, worldUp.x - instance.localPosition.x) * Mathf.Rad2Deg);
        }

        public static void SetAnchorStrech(this RectTransform instance)
        {
            instance.anchorMin = Vector2.zero;

            instance.anchorMax = Vector2.one;

            instance.offsetMin = Vector2.zero;

            instance.offsetMax = Vector2.zero;
        }

        public static void FitSizeMin(this RectTransform instance, Vector2 sizeDelta)
        {
            if (instance.sizeDelta.x / instance.sizeDelta.y > sizeDelta.x / sizeDelta.y)
            {
                sizeDelta.y = sizeDelta.x * instance.sizeDelta.y / instance.sizeDelta.x;
            }

            else
            {
                sizeDelta.x = sizeDelta.y * instance.sizeDelta.x / instance.sizeDelta.y;
            }

            instance.anchoredPosition = Vector2.zero;

            instance.sizeDelta = sizeDelta;
        }

        public static void FitSizeMax(this RectTransform instance, Vector2 sizeDelta)
        {
            if (instance.sizeDelta.x / instance.sizeDelta.y > sizeDelta.x / sizeDelta.y)
            {
                sizeDelta.x = sizeDelta.y * instance.sizeDelta.x / instance.sizeDelta.y;
            }

            else
            {
                sizeDelta.y = sizeDelta.x * instance.sizeDelta.y / instance.sizeDelta.x;
            }

            instance.anchoredPosition = Vector2.zero;

            instance.sizeDelta = sizeDelta;
        }
    }
}