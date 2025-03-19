using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using System;

namespace ZL.Unity.Tweeners
{
    [Serializable]

    public sealed class FloatTweener : ValueTweener<float, float, FloatOptions>
    {
        protected override TweenerCore<float, float, FloatOptions> To
            
            (DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration)
        {
            return DOTween.To(getter, setter, endValue, duration);
        }
    }
}