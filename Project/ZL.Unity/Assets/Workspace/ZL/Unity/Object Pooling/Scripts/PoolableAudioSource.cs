using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Audio Source (Poolable)")]

    [RequireComponent(typeof(AudioSource))]

    public sealed class PoolableAudioSource : PoolablePlayable<AudioSource>
    {
        public override bool IsPlaying => @base.isPlaying;

        public float Volume
        {
            get => @base.volume;

            set => @base.volume = value;
        }
    }
}