using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pooling/Audio Source (Pooled)")]

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

        public override bool IsPlaying => @base.isPlaying;

        public void Initialize(PooledAudioSource original)
        {
            @base.Initialize(original.@base);
        }
    }
}