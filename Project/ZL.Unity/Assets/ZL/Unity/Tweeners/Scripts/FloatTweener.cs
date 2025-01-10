using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

namespace ZL.Unity.Tweeners
{
    public sealed class FloatTweener : Tweener<float, float, FloatOptions>
    {
        public FloatTweener(DOGetter<float> getter, DOSetter<float> setter) : base(getter, setter)
        {

        }

        protected override TweenerCore<float, float, FloatOptions> Instantiate(DOGetter<float> getter, DOSetter<float> setter)
        {
            return DOTween.To(getter, setter, default, default);
        }
    }
}