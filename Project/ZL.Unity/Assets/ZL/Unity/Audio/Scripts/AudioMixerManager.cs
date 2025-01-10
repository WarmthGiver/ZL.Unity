using UnityEngine;

using UnityEngine.Audio;

using ZL.Unity.Collections;

namespace ZL.Unity.Audio
{
    [DisallowMultipleComponent]

    public sealed class AudioMixerManager : Singleton<AudioMixerManager>
    {
        [Space]

        [SerializeField, Essential]

        [Button("LoadAudioMixerParameters", "Load Parameters")]

        private AudioMixer audioMixer;

        [SerializeField]

        [Button(nameof(LoadVolumes))]

        [Button(nameof(SaveVolumes))]

        private SerializableDictionary<string, float, FloatPref> paremeters;

#if UNITY_EDITOR

        public void LoadAudioMixerParameters()
        {
            paremeters.Clear();

            if (audioMixer != null)
            {
                foreach (var audioMixerGroup in audioMixer.FindMatchingGroups(string.Empty))
                {
                    var key = audioMixerGroup.name;

                    audioMixer.GetFloat(key, out float value);

                    FloatPref volumePref = new(key, value);

                    volumePref.TryLoadValue();

                    paremeters.Add(volumePref);
                }
            }

            UnityEditor.EditorUtility.SetDirty(this);
        }

        private void OnValidate()
        {

        }

#endif

        protected override void OnAwake()
        {
            LoadVolumes();
        }

        public void SaveVolumes()
        {
            foreach (var volumePref in paremeters)
            {
                volumePref.SaveValue();
            }
        }

        public void LoadVolumes()
        {
            foreach (var volumePref in paremeters)
            {
                volumePref.TryLoadValue();
            }
        }

        public float GetVolume(string key)
        {
            return paremeters[key];
        }

        public void SetVolume(string key, float value)
        {
            paremeters[key] = value;

            audioMixer.SetVolume(key, value);
        }
    }
}