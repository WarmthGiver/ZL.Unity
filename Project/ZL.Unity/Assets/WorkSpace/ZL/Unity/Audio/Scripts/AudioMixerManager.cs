#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using UnityEngine.Audio;

using ZL.Unity.Collections;

using ZL.Unity.IO;

using ZL.Unity.Singleton;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Mixer Manager (Singleton)")]

    public sealed class AudioMixerManager : MonoSingleton<AudioMixerManager>
    {
        [Space]

        [Essential]

        [PropertyField]

        [Button("LoadAudioMixerParameters", "Load Parameters")]

        [UsingCustomProperty]

        [SerializeField]

        private AudioMixer audioMixer = null;

        [Space]

        [Button(nameof(LoadVolumes))]

        [Button(nameof(SaveVolumes))]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private SerializableDictionary<string, float, FloatPref> parameterPrefs = null;

        #if UNITY_EDITOR

        private void OnValidate()
        {
            if (parameterPrefs == null)
            {
                return;
            }

            foreach (var parameterPref in parameterPrefs)
            {
                parameterPref.Value = Mathf.Clamp01(parameterPref.Value);
            }
        }

        public void LoadAudioMixerParameters()
        {
            parameterPrefs.Clear();

            if (audioMixer != null)
            {
                foreach (var audioMixerGroup in audioMixer.FindMatchingGroups(""))
                {
                    var key = audioMixerGroup.name;

                    audioMixer.GetFloat(key, out float value);

                    var volumePref = new FloatPref(key, value);

                    volumePref.TryLoadValue();

                    parameterPrefs.Add(volumePref);
                }
            }

            EditorUtility.SetDirty(this);
        }

        #endif

        private void Start()
        {
            foreach (var parameterPref in parameterPrefs)
            {
                parameterPref.OnValueChanged += (value) =>
                {
                    audioMixer.SetVolume(parameterPref.Key, value);
                };
            }

            LoadVolumes();
        }

        public void LoadVolumes()
        {
            foreach (var parameterPref in parameterPrefs)
            {
                parameterPref.TryLoadValue();
            }
        }

        public void SaveVolumes()
        {
            foreach (var parameterPref in parameterPrefs)
            {
                parameterPref.SaveValue();
            }
        }

        public float GetVolume(string key)
        {
            return parameterPrefs[key];
        }

        public void SetVolume(string key, float value)
        {
            parameterPrefs[key] = value;
        }
    }
}