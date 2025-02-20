using System;

using UnityEngine;

namespace ZL.CS.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Listener Controller")]

    [DisallowMultipleComponent]

    public sealed class AudioListenerController : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private bool pause = false;

        [Space]

        [SerializeField, Range(0f, 1f)]

        private float volume = 0f;

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                AudioListener.volume = volume;

                AudioListener.pause = pause;
            }
        }

#if UNITY_EDITOR

        private void Update()
        {
            volume = AudioListener.volume;

            pause = AudioListener.pause;
        }

#endif

        private void Awake()
        {
            AudioListener.volume = volume;

            AudioListener.pause = pause;
        }
    }
}