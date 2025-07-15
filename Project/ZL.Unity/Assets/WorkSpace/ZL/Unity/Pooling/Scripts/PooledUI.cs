using UnityEngine;

using ZL.Unity.Tweening;

namespace ZL.Unity.Pooling
{
    public abstract class PooledUI : PooledObject
    {
        [Space]

        [GetComponent]

        [PropertyField]

        [Margin]

        [ReadOnlyIfEditMode]

        [Button(nameof(Appear))]

        [Button(nameof(Disappear))]

        [UsingCustomProperty]

        [SerializeField]

        protected Fader fader = null;

        private void Awake()
        {
            if (fader != null)
            {
                fader.OnFadedInEvent.AddListener(OnAppeared);

                fader.OnFadedOutEvent.AddListener(OnDisappeared);
            }
        }

        public override void Appear()
        {
            if (fader != null)
            {
                fader.FadeIn();
            }

            else
            {
                base.Appear();
            }
        }

        public override void Disappear()
        {
            if (fader != null)
            {
                fader.FadeOut();
            }

            else
            {
                base.Disappear();
            }
        }
    }
}