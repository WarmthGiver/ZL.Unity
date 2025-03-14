using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public abstract class ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [SerializeField]

        private float duration = 0f;

        public float Duration
        {
            get => duration;

            set => duration = value;
        }

        [SerializeField]

        private Ease ease = Ease.Linear;

        public Ease Ease
        {
            get => ease;

            set => ease = value;
        }

        [Space]

        [SerializeField]

        private bool isIndependentUpdate = false;

        public bool IsIndependentUpdate
        {
            get => isIndependentUpdate;

            set => isIndependentUpdate = value;
        }

        [Space]

        [SerializeField]

        private bool loop = false;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf("loop", false)]

        private int loops = -1;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf("loop", false)]

        private LoopType loopType = LoopType.Restart;

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

        protected abstract TweenerCore<T1, T2, TPlugOptions> To

            (DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration);

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue)
        {
            return Tween(endValue, duration);
        }

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue, float duration)
        {
            Current.Kill();

            Current = To(getter, setter, endValue, duration);

            Current.SetEase(ease);

            if (isIndependentUpdate == true)
            {
                Current.SetUpdate(isIndependentUpdate);
            }

            if (loop == true)
            {
                Current.SetLoops(loops, loopType);
            }

            Current.SetAutoKill(false);

            Current.SetRecyclable(true);

            Current.Restart();

            return Current;
        }
    }
}