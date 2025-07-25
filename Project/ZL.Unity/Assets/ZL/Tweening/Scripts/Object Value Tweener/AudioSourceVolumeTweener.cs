using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Audio Source Tweener")]

    public sealed class AudioSourceVolumeTweener : ObjectValueTweener<FloatTweener, float, float, FloatOptions>
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private AudioSource audioSource = null;

        public override float Value
        {
            get => audioSource.volume;
            
            set => audioSource.volume = value;
        }
    }
}