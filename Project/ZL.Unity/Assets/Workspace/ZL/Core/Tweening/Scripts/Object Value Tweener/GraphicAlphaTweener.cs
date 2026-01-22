using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Graphic Alpha Tweener")]

    public sealed class GraphicAlphaTweener : GraphicValueTweener<FloatTweener, float, float, FloatOptions>
    {
        public override float Value
        {
            get => graphic.color.a;

            set => graphic.color = graphic.color.Alpha(value);
        }
    }
}