using UnityEngine;

namespace ZL.CS.Unity.UI
{
    [AddComponentMenu("ZL/UI/Window(UI) Minimizer")]

    public sealed class UIWindowMinimizer : RectTransformObject
    {
        [SerializeField]

        private Vector2 minimizedSize = Vector2.zero;

        [SerializeField]

        private bool isMinimized = false;

        public bool IsMinimized
        {
            get => isMinimized;

            set
            {
                isMinimized = value;

                Minimize();
            }
        }

        private Vector2 originalSize;

        private void Awake()
        {
            Minimize();
        }

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                Minimize();
            }
        }

        private void Minimize()
        {
            if (isMinimized == true)
            {
                originalSize = rectTransform.sizeDelta;

                rectTransform.sizeDelta = minimizedSize;
            }

            else
            {
                rectTransform.sizeDelta = originalSize;
            }
        }
    }
}