using UnityEngine;

namespace ZL.CS.Unity.UI
{
    [AddComponentMenu("ZL/UI/Rect Transform Fitter")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(RectTransform))]

    public sealed class RectTransformFitter : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RectTransform rectTransform;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Button(nameof(FitParentSizeMin))]

        [Button(nameof(FitParentSizeMax))]

        private RectTransform fitTarget = null;

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