using DG.Tweening;
using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public abstract class ComponentValueTweener<TValueTweener, T1, T2, TPlugOptions> : MonoBehaviour

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [Space]

        [SerializeField]

        protected TValueTweener tweener;

        public TweenerCore<T1, T2, TPlugOptions> Current => tweener.Current;

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue) => Tween(endValue);
    }
}