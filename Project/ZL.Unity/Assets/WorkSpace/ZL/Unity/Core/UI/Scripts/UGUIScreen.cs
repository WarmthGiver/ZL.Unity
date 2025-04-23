using DG.Tweening;

using UnityEngine;

using UnityEngine.Events;

using ZL.Tweeners;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/UGUI Screen")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupAlphaTweener))]

    public sealed class UGUIScreen : MonoBehaviour
    {
        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [EmptyField]

        private CanvasGroup canvasGroup;

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [EmptyField]

        private CanvasGroupAlphaTweener alphaTweener;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponentInParentOnly]

        [ReadOnly(true)]

        private UGUIScreenGroup screenGroup;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [PropertyField]

        [ReadOnlyWhenEditMode]

        [Button(nameof(ToggleFaded))]

        private bool isFadedIn = false;

        public bool IsFadedIn
        {
            get => isFadedIn;
        }

        [Space]

        [SerializeField]

        private UnityEvent onFadeInEvent;

        [Space]

        [SerializeField]

        private UnityEvent onFadedInEvent;

        [Space]

        [SerializeField]

        private UnityEvent onFadeOutEvent;

        [Space]

        [SerializeField]

        private UnityEvent onFadedOutEvent;

        private void Awake()
        {
            if (isFadedIn == true)
            {
                canvasGroup.alpha = 1f;

                gameObject.SetActive(true);
            }

            else
            {
                canvasGroup.alpha = 0f;

                gameObject.SetActive(false);
            }
        }

        public void ToggleFaded()
        {
            if (isFadedIn == true)
            {
                FadeOut();
            }

            else
            {
                FadeIn();
            }
        }

        public void FadeIn()
        {
            screenGroup?.SwapCurrent(this);

            gameObject.SetActive(true);

            isFadedIn = true;

            onFadeInEvent.Invoke();

            alphaTweener.Tween(1f).OnComplete(OnFadedIn);
        }

        private void OnFadedIn()
        {
            onFadedInEvent.Invoke();
        }

        public void FadeOut()
        {
            isFadedIn = false;

            onFadeOutEvent.Invoke();

            alphaTweener.Tween(0f).OnComplete(OnFadedOut);
        }

        private void OnFadedOut()
        {
            onFadedOutEvent.Invoke();

            gameObject.SetActive(false);
        }
    }
}