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

        private bool useCurve = false;

        public bool UseCurve
        {
            get => useCurve;

            set => useCurve = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf("useCurve", true)]

        private Ease ease = Ease.OutQuad;

        public Ease Ease
        {
            get => ease;

            set => ease = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf("useCurve", false)]

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

        private TweenerCore<T1, T2, TPlugOptions> current;

        public TweenerCore<T1, T2, TPlugOptions> Current => current;

        protected abstract TweenerCore<T1, T2, TPlugOptions> Instantiate
            
            (DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration);

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue)//, bool ignoreElapsed = false)
        {
            /*float remain = 0f;

            if (ignoreElapsed == false)
            {
                remain = current.Remain();
            }*/

            current.Kill();

            current = Instantiate(getter, setter, endValue, duration);// - remain);

            if (useCurve == true)
            {
                current.SetEase(animCurve);
            }

            else
            {
                current.SetEase(ease);
            }
            

            current.SetUpdate(isIndependentUpdate);

            current.SetAutoKill(false);

            current.SetRecyclable(true);

            current.Restart();

            return current;
        }
    }
}