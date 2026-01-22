using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    public abstract class LightValueTweener<TValueTweener, T1, T2, TPlugOptions> : ObjectValueTweener<TValueTweener, T1, T2, TPlugOptions>

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        #pragma warning disable

        protected Light light = null;

        #pragma warning restore
    }
}