using UnityEngine;

namespace ZL.ObjectPooling
{
    using ZL.Tweeners;

    [AddComponentMenu("ZL/Object Pool/Audio Source (Pooled)")]

    [RequireComponent(typeof(AudioSource))]

    public sealed class PooledAudioSource : PooledPlayable<PooledAudioSource>
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private AudioSource @base;

        public float Volume
        {
            get => @base.volume;

            set => @base.volume = value;
        }

        private FloatTweener volumeTweener;

        public override bool IsPlaying => @base.isPlaying;

        private void Awake()
        {
            volumeTweener = new(() => Volume, value => Volume = value);
        }

        public void Initialize(PooledAudioSource original)
        {
            @base.Initialize(original.@base);
        }

        public FloatTweener TweenVolume(float value, float duration)
        {
            volumeTweener.Tween(value, duration);

            return volumeTweener;
        }
    }
}