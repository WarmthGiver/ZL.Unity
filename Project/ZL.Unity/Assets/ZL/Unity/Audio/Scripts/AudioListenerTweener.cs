using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Listener Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioListener))]

    public sealed class AudioListenerTweener : Singleton<AudioListenerTweener>
    {
        private FloatTweener volumeTweener;

        static AudioListenerTweener()
        {
            if (Instance == null)
            {
                var type = typeof(AudioListenerTweener);

                new GameObject(type.Name.ToTitleCase(), type);

                Creator.Create<AudioListenerTweener>(null);
            }
        }

        protected override void OnAwake()
        {
            volumeTweener = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }

        public FloatTweener TweenVolume(float endValue, float duration)
        {
            volumeTweener.Tween(endValue, duration);

            return volumeTweener;
        }
    }
}