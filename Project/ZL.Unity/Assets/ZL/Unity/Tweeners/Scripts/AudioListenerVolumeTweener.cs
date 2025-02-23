using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public static class AudioListenerVolumeTweener
    {
        private static readonly FloatTweener volumeTweener;

        static AudioListenerVolumeTweener()
        {
            volumeTweener = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }

        public static TweenerCore<float, float, FloatOptions> Tween(float endValue, float duration)
        {
            return volumeTweener.Tween(endValue, duration);
        }
    }
}