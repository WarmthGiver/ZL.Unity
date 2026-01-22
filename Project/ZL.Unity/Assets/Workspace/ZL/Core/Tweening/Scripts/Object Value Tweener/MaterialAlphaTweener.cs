using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Material Alpha Tweener")]

    public sealed class MaterialAlphaTweener : MaterialValueTweener<FloatTweener, float, float, FloatOptions>
    {
        public override float Value
        {
            get => material.color.a;

            set => material.color = material.color.Alpha(value);
        }
    }
}