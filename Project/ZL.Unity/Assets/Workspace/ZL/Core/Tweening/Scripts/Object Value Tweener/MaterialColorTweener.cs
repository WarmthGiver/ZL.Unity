using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Material Color Tweener")]

    public sealed class MaterialColorTweener : MaterialValueTweener<ColorTweener, Color, Color, ColorOptions>
    {
        public override Color Value
        {
            get => material.color;

            set => material.color = value;
        }
    }
}