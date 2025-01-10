using System;

using UnityEngine;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Listener Controller")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioListener))]

    public sealed class AudioListenerController : MonoBehaviour
    {
        public static AudioListenerController Instance { get; private set; } = null;

        [Space]

        [SerializeField, Range(0f, 1f)]

        private float volume = 1f;

        public static float Volume
        {
            get => Instance.volume;

            set
            {
                Instance.volume = value;

                AudioListener.volume = value;
            }
        }

        private void OnEnable()
        {
            if (Instance != null)
            {
                Instance.enabled = false;
            }

            Instance = this;

            AudioListener.volume = volume;
        }

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                AudioListener.volume = volume;
            }
        }
    }
}