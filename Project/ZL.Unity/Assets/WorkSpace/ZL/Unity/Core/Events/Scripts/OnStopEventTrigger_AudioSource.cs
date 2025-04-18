using UnityEngine;

namespace ZL.Unity.Events
{
    [AddComponentMenu("ZL/Pooling/On Stop Event Trigger (Audio Source)")]

    [RequireComponent(typeof(AudioSource))]

    public sealed class OnStopEventTrigger_AudioSource :
        
        OnStopEventTrigger<AudioSource>
    {
        public override bool IsStoped
        {
            get => !target.isPlaying;
        }

        public float Volume
        {
            get => target.volume;

            set => target.volume = value;
        }
    }
}