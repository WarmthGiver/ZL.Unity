using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public sealed class ColorTweener : Tweener<Color, Color, ColorOptions>
    {
        public ColorTweener(DOGetter<Color> getter, DOSetter<Color> setter) : base(getter, setter)
        {

        }

        protected override TweenerCore<Color, Color, ColorOptions> Instantiate(DOGetter<Color> getter, DOSetter<Color> setter)
        {
            return DOTween.To(getter, setter, default, default);
        }
    }
}