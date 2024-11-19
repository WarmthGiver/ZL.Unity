using UnityEngine;

using UnityEngine.UI;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/Image (New)")]

    public sealed class NewImage : Image
    {
        [SerializeField]

        private RectTransform fitParentSizeTarget;

#pragma warning disable CS0114

        private void Reset()
        {
            transform.TryGetComponentInParentOnly(out fitParentSizeTarget);
        }

#pragma warning restore CS0114

        public void FitParentSizeMin()
        {
            rectTransform.FitSizeMin(fitParentSizeTarget.sizeDelta);
        }

        public void FitParentSizeMax()
        {
            rectTransform.FitSizeMax(fitParentSizeTarget.sizeDelta);
        }

        private Vector2 sizeDelta = Vector3.zero;

        private Vector3 localRotation = Vector3.zero;

        public void Line(in Vector2 endPosition, float thickness)
        {
            sizeDelta.x = Vector2.Distance(transform.localPosition, endPosition);

            sizeDelta.y = thickness;

            rectTransform.sizeDelta = sizeDelta;

            localRotation.z = Mathf.Atan2(endPosition.y - transform.localPosition.y, endPosition.x - transform.localPosition.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.Euler(localRotation);
        }
    }
}