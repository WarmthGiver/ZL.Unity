using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.CS.Unity.Tweeners
{
    public abstract class ComponentValueTweener<TValueTweener, T1, T2, TPlugOptions> : MonoBehaviour

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        protected TValueTweener tweener;

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue, float duration)
        {
            return tweener.Tween(endValue, duration);
        }
    }
}