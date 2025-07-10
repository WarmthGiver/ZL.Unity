using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    public abstract class MaterialPropertyTweener<TValueTweener, T1, T2, TPlugOptions> : MaterialValueTweener<TValueTweener, T1, T2, TPlugOptions>

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [SerializeField]

        protected string propertyName = "";
    }
}