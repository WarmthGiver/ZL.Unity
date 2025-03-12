using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using System;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [Serializable]

    public abstract class ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [SerializeField]

        private float duration = 1f;

        public float Duration
        {
            get => duration;

            set => duration = value;
        }

        [Space]

        [SerializeField]

        private bool useCustomEase = false;

        public bool UseCustomEase
        {
            get => useCustomEase;

            set => useCustomEase = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(useCustomEase), true)]

        private Ease ease = Ease.OutQuad;

        public Ease Ease
        {
            get => ease;

            set => ease = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(useCustomEase), false)]

        [Alias("Ease")]

        private AnimationCurve animCurve;

        public AnimationCurve AnimCurve
        {
            get => animCurve;

            set => animCurve = value;
        }

        [Space]

        [SerializeField]

        private bool isIndependentUpdate = false;

        public bool IsIndependentUpdate
        {
            get => isIndependentUpdate;

            set => isIndependentUpdate = value;
        }

        protected DOGetter<T1> getter;

        public DOGetter<T1> Getter
        {
            get => getter;

            set => getter = value;
        }

        protected DOSetter<T1> setter;

        public DOSetter<T1> Setter
        {
            get => setter;

            set => setter = value;
        }

        public TweenerCore<T1, T2, TPlugOptions> Current { get; private set; }

        protected abstract TweenerCore<T1, T2, TPlugOptions> Instantiate
            
            (DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration);

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue)
        {
            Current.Kill();

            Current = Instantiate(getter, setter, endValue, duration);

            if (useCustomEase == false)
            {
                Current.SetEase(ease);
            }

            else
            {
                Current.SetEase(animCurve);
            }
            
            Current.SetUpdate(isIndependentUpdate);

            Current.SetAutoKill(false);

            Current.SetRecyclable(true);

            Current.Restart();

            return Current;
        }
    }
}