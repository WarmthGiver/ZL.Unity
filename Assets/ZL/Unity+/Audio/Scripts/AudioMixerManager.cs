using UnityEngine;

using UnityEngine.Audio;

namespace ZL.Audio
{
    using ZL.Collections;

    [DisallowMultipleComponent]

    public sealed class AudioMixerManager : Singleton<AudioMixerManager>
    {
        [Space]

        [SerializeField, Essential]

        [Button(nameof(Initialize))]

        private AudioMixer audioMixer;

        [SerializeField]

        [Button(nameof(SaveVolumes))]

        [Button(nameof(LoadVolumes))]

        private SerializableDictionary<string, float, FloatPref> volumePrefs;

#if UNITY_EDITOR

        public void Initialize()
        {
            volumePrefs.Clear();

            if (audioMixer != null)
            {
                foreach (var audioMixerGroup in audioMixer.FindMatchingGroups(string.Empty))
                {
                    var key = audioMixerGroup.name;

                    audioMixer.GetFloat(key, out float value);

                    FloatPref volumePref = new(key, value);

                    volumePref.TryLoadValue();

                    volumePrefs.Add(volumePref);
                }
            }
        }

#endif

        protected override void Awake()
        {
            base.Awake();

            LoadVolumes();
        }

        public void LoadVolumes()
        {
            foreach (var volumePref in volumePrefs)
            {
                volumePref.TryLoadValue();
            }
        }

        public void SaveVolumes()
        {
            foreach (var volumePref in volumePrefs)
            {
                volumePref.SaveValue();
            }
        }

        public float GetVolume(string key)
        {
            return volumePrefs[key];
        }

        public void SetVolume(string key, float value)
        {
            volumePrefs[key] = value;

            audioMixer.SetVolume(key, value);
        }
    }
}