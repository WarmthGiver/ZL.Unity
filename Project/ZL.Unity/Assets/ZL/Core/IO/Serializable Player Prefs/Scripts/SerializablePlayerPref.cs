using System;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.IO
{
    public abstract class SerializablePlayerPref<TValue> : PlayerPrefs, IKeyValuePair<string, TValue>
    {
        [ReadOnlyIfPlayMode(true)]

        [UsingCustomProperty]

        [SerializeField]

        private string key = "";

        public string Key
        {
            get => key;

            set => key = value;
        }

        [SerializeField]

        private TValue value = default;

        public TValue Value
        {
            get => value;

            set
            {
                this.value = value;

                OnValueChanged?.Invoke(value);
            }
        }

        public event Action<TValue> OnValueChanged = null;

        public SerializablePlayerPref() { }

        public SerializablePlayerPref(string key, TValue value)
        {
            this.key = key;

            this.value = value;
        }

        public void Refresh()
        {
            Value = value;
        }

        public bool TryLoadValue()
        {
            if (HasKey(key) == true)
            {
                LoadValue();

                return true;
            }

            SaveValue();

            return false;
        }

        public abstract void LoadValue();

        public void SaveValue(TValue value)
        {
            Value = value;

            SaveValue();
        }

        public abstract void SaveValue();

        public override string ToString()
        {
            return $"[{key}, {value}]";
        }
    }
}