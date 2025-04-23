using DG.Tweening.Plugins.Options;

using UnityEngine;

using UnityEngine.UI;

namespace ZL.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Graphic Color Tweener")]

    public sealed class GraphicColorTweener : ComponentValueTweener<ColorTweener, Color, Color, ColorOptions>
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private Graphic graphic;

        protected override Color Value
        {
            get => graphic.color;

            set => graphic.color = value;
        }
    }
}