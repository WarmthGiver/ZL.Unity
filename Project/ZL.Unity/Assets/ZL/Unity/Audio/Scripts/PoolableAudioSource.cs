using UnityEngine;

using ZL.Unity.ObjectPooling;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Source (Poolable)")]

    [RequireComponent(typeof(AudioSource))]

    public sealed class PoolableAudioSource : PoolablePlayable<AudioSource>
    {
        public override bool IsPlaying => @base.isPlaying;

        public float Volume
        {
            get => @base.volume;

            set => @base.volume = value;
        }

        public void Initialize(PoolableAudioSource original)
        {
            @base.Initialize(original.@base);
        }
    }
}