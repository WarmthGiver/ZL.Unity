using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/UI/Rect Transform Fitter")]

    public sealed class RectTransformFitter : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private RectTransform rectTransform = null;

        [Space]

        [Essential]

        [PropertyField]

        [Margin]

        [Button(nameof(FitParentSizeMin))]

        [Button(nameof(FitParentSizeMax))]

        [UsingCustomProperty]

        [SerializeField]

        private RectTransform fitTarget = null;

        private void Reset()
        {
            transform.TryGetComponentInParentOnly(out fitTarget);
        }

        public void FitParentSizeMin()
        {
            rectTransform.FitSizeMin(fitTarget.sizeDelta);
        }

        public void FitParentSizeMax()
        {
            rectTransform.FitSizeMax(fitTarget.sizeDelta);
        }
    }
}