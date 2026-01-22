using System;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/SO/Google Sheet/String Table Manager (Singleton)")]

    public sealed class StringTableManager : MonoSingleton<StringTableManager>
    {
        [Space]

        [Button(nameof(LoadLanguage))]

        [Button(nameof(SaveLanguage))]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private EnumPref<StringTableLanguage> targetLanguagePref =
            
            new EnumPref<StringTableLanguage>("TargetLanguage", StringTableLanguage.Korean);

        public StringTableLanguage TargetLanguage
        {
            get => targetLanguagePref.Value;

            set => targetLanguagePref.Value = value;
        }

        public event Action OnLanguageChangedAction = null;

        private void OnValidate()
        {
            targetLanguagePref.Value = targetLanguagePref.Value;
        }

        protected override void Awake()
        {
            base.Awake();

            targetLanguagePref.OnValueChangedAction += (value) =>
            {
                OnLanguageChangedAction?.Invoke();
            };

            LoadLanguage();
        }

        public void LoadLanguage()
        {
            targetLanguagePref.TryLoadValue();
        }

        public void SaveLanguage()
        {
            targetLanguagePref.SaveValue();
        }
    }
}