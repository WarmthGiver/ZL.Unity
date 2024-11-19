using System;

using UnityEngine;

namespace ZL
{
    using ZL.Tweeners;

    [AddComponentMenu("ZL/Audio/Audio Listener+")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioListener))]

    public sealed class AudioListenerPlus : Singleton<AudioListenerPlus>
    {
        [Space]

        [SerializeField, Range(0f, 1f)]

        private float volume = 1f;

        public float Volume
        {
            get => volume;

            set
            {
                volume = value;

                AudioListener.volume = value;
            }
        }

        private FloatTweener volumeTweener;

        protected override void Awake()
        {
            base.Awake();

            AudioListener.volume = volume;

            volumeTweener = new(() => Volume, value => Volume = value);
        }

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                AudioListener.volume = volume;
            }
        }

        public FloatTweener TweenVolume(float endValue, float duration)
        {
            volumeTweener.Tween(endValue, duration);

            return volumeTweener;
        }
    }
}