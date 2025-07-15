using DG.Tweening.Plugins.Options;

using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Fader")]

    public sealed class Fader : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [PropertyField]

        [Margin]

        [ReadOnlyIfEditMode]

        [Button(nameof(FadeIn))]

        [Button(nameof(FadeOut))]

        [UsingCustomProperty]

        [SerializeField]

        private ObjectValueTweener<FloatTweener, float, float, FloatOptions> tweener = null;

        [Space]

        [SerializeField]

        private UnityEvent onFadeInEvent = null;

        public UnityEvent OnFadeInEvent
        {
            get => onFadeInEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onFadedInEvent = null;

        public UnityEvent OnFadedInEvent
        {
            get => onFadedInEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onFadeOutEvent = null;

        public UnityEvent OnFadeOutEvent
        {
            get => onFadeOutEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onFadedOutEvent = null;

        public UnityEvent OnFadedOutEvent
        {
            get => onFadedOutEvent;
        }

        /// <summary>
        /// Fade alpha from 0 to 1.<br/>
        /// ���ĸ� 0���� 1���� ���̵��մϴ�.<br/>
        /// </summary>
        /// <param name = "duration">
        /// Fade time;<br/>
        /// -1 = Use tweener defaults<br/>
        /// ���̵� �ð�;<br/>
        /// -1 = Tweener �⺻�� ���<br/>
        /// </param>
        public void FadeIn()
        {
            gameObject.SetActive(true);

            onFadeInEvent.Invoke();

            tweener.SetEndValue(1f);

            tweener.Play();

            tweener.Current.onComplete += OnFadedIn;
        }

        private void OnFadedIn()
        {
            OnFadedInEvent.Invoke();
        }

        /// <summary>
        /// Fade alpha from 1 to 0.<br/>
        /// ���ĸ� 1���� 0���� ���̵��մϴ�.<br/>
        /// </summary>
        /// <param name = "duration">
        /// Fade time;<br/>
        /// -1 = Use tweener defaults<br/>
        /// ���̵� �ð�;<br/>
        /// -1 = Tweener �⺻�� ���<br/>
        /// </param>
        public void FadeOut()
        {
            onFadeOutEvent.Invoke();

            tweener.SetEndValue(0f);

            tweener.Play();

            tweener.Current.onComplete += OnFadedOut;
        }

        private void OnFadedOut()
        {
            OnFadedOutEvent.Invoke();

            gameObject.SetActive(false);
        }
    }
}