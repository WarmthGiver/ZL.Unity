using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Light Color Tweener")]

    public sealed class LightColorTweener : LightValueTweener<ColorTweener, Color, Color, ColorOptions>
    {
        public override Color Value
        {
            get => light.color;
            
            set => light.color = value;
        }
    }
}