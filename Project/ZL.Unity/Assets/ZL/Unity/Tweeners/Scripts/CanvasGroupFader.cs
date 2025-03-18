using DG.Tweening;

using UnityEngine;

using UnityEngine.Events;

using ZL.Unity.Tweeners;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Canvas Group Fader")]

    [DisallowMultipleComponent]

    public class CanvasGroupFader : CanvasGroupAlphaTweener
    {
        [Space]

        [SerializeField]

        private bool isFadedIn = false;

        public bool IsFadedIn
        {
            get => isFadedIn;

            set
            {
                isFadedIn = value;

                if (isFadedIn == true)
                {
                    gameObject.SetActive(true);

                    canvasGroup.alpha = 1f;
                }

                else
                {
                    canvasGroup.alpha = 0f;

                    gameObject.SetActive(false);
                }
            }
        }

        [Space]

        [SerializeField]

        private UnityEvent eventOnFadeIn;

        [Space]

        [SerializeField]

        private UnityEvent eventOnFadeOut;

        private bool interactable;

        protected override void Awake()
        {
            base.Awake();

            IsFadedIn = isFadedIn;
        }

        public void SetFaded(bool value)
        {
            SetFaded(value, tweener.Duration);
        }

        public void SetFaded(bool value, float duration)
        {
            isFadedIn = value;

            if (isFadedIn == true)
            {
                gameObject.SetActive(true);

                Tween(1f, duration).OnComplete(OnFadedIn);
            }

            else
            {
                interactable = canvasGroup.interactable;

                canvasGroup.interactable = false;

                Tween(0f, duration).OnComplete(OnFadedOut);
            }
        }

        protected virtual void OnFadedIn()
        {
            eventOnFadeIn.Invoke();
        }

        protected virtual void OnFadedOut()
        {
            eventOnFadeOut.Invoke();

            gameObject.SetActive(false);

            canvasGroup.interactable = interactable;
        }
    }
}