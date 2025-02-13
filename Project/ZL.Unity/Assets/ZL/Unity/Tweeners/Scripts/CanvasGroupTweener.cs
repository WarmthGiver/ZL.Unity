﻿using DG.Tweening;

using System;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Canvas Group Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroup))]

    public sealed class CanvasGroupTweener : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private CanvasGroup canvasGroup;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent(1)]

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

        [AddIndent(1), SerializeField, Range(0f, 1f), ReadOnlyWhenPlayMode]

        private float minAlpha = 0f;

        [AddIndent(1), SerializeField, Range(0f, 1f), ReadOnlyWhenPlayMode]

        private float maxAlpha = 1f;

        [AddIndent(1), SerializeField]

        private float fadeDuration = 0.1f;

        private FloatTweener alphaTweener;

        private void Awake()
        {
            IsFaded = isFaded;

            alphaTweener = new(() => canvasGroup.alpha, value => canvasGroup.alpha = value);
        }

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                IsFaded = isFaded;
            }
        }

        public void TweenFaded(bool value)
        {
            gameObject.SetActive(true);

            isFaded = value;

            if (isFaded == true)
            {
                alphaTweener.Tween(minAlpha, fadeDuration);
            }

            else
            {
                alphaTweener.Tween(maxAlpha, fadeDuration).
                    
                    OnComplete(TrySetActiveFalse);
            }
        }

        private void TrySetActiveFalse()
        {
            if (disableOnFaded == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}