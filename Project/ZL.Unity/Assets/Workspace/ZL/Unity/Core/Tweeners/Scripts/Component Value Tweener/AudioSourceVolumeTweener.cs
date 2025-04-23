using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Source Tweener")]

    [RequireComponent(typeof(AudioSource))]

    public sealed class AudioSourceVolumeTweener : ComponentValueTweener<FloatTweener, float, float, FloatOptions>
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private AudioSource audioSource;

        protected override float Value
        {
            get => audioSource.volume;
            
            set => audioSource.volume = value;
        }
    }
}