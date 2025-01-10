using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Source Tweener")]

    [RequireComponent(typeof(AudioSource))]

    public sealed class AudioSourceTweener : MonoBehaviour
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

        private void Start()
        {
            volumeTweener = new(() => Volume, value => Volume = value);
        }

        public FloatTweener TweenVolume(float value, float duration)
        {
            volumeTweener.Tween(value, duration);

            return volumeTweener;
        }
    }
}