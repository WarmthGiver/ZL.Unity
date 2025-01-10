using System;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroup))]

    public sealed class CanvasGroupTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private CanvasGroup canvasGroup;

        [Space]

        [Indent(1), SerializeField]

        private bool disableOnFaded = true;

        [SerializeField]

        private bool isFaded = false;

        public bool IsFaded
        {
            get => isFaded;

            set
            {
                isFaded = value;

                canvasGroup.alpha = isFaded ? minAlpha : maxAlpha;
            }
        }

        [Indent(1), SerializeField, Range(0f, 1f), ReadOnlyInPlayMode]

        private float minAlpha = 0f;

        [Indent(1), SerializeField, Range(0f, 1f), ReadOnlyInPlayMode]

        private float maxAlpha = 1f;

        [Indent(1), SerializeField]

        private float fadeDuration = 0.1f;

        private FloatTweener alphaTweener;

        private void Awake()
        {
            IsFaded = isFaded;

            alphaTweener = new(() => canvasGroup.alpha, value => canvasGroup.alpha = value);
        }

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                IsFaded = isFaded;
            }
        }

        public FloatTweener TweenFaded(bool value)
        {
            isFaded = value;

            if (disableOnFaded)
            {
                if (isFaded)
                {
                    gameObject.SetActive(true);
                }

                else
                {
                    alphaTweener.OnComplete(SetActiveFalse);
                }
            }

            alphaTweener.Tween(isFaded ? minAlpha : maxAlpha, fadeDuration);

            return alphaTweener;
        }

        private void SetActiveFalse()
        {
            gameObject.SetActive(false);
        }
    }
}