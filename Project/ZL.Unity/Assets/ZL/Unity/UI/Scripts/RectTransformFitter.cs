using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Rect Transform Fitter")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(RectTransform))]

    public sealed class RectTransformFitter : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        [Space]

        [SerializeField]

        [Button("FitParentSizeMin")]

        [Button("FitParentSizeMax")]

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