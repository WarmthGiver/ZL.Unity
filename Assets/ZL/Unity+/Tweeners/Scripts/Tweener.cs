using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;
using System;

namespace ZL.Tweeners
{
    public abstract class Tweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        private readonly TweenerCore<T1, T2, TPlugOptions> tweener;

        public Tweener(DOGetter<T1> getter, DOSetter<T1> setter)
        {
            tweener = NewTweener(getter, setter);

            tweener.Pause();

            tweener.SetAutoKill(false);

            //tweener.SetRecyclable(true);
        }

        protected abstract TweenerCore<T1, T2, TPlugOptions> NewTweener(DOGetter<T1> getter, DOSetter<T1> setter);

        public void Tween(T2 endValue, float duration, bool snapStartValue = true)
        {
            tweener.ChangeEndValue(endValue, duration, snapStartValue);

            tweener.Restart();
        }

        public void OnComplete(Action action)
        {
            void Action()
            {
                action.Invoke();

                tweener.OnComplete(null);
            }

            tweener.OnComplete(Action);
        }
    }
}