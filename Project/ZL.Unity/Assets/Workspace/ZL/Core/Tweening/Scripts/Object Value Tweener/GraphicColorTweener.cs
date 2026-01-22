using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Graphic Color Tweener")]

    public sealed class GraphicColorTweener : GraphicValueTweener<ColorTweener, Color, Color, ColorOptions>
    {
        public override Color Value
        {
            get => graphic.color;

            set => graphic.color = value;
        }
    }
}