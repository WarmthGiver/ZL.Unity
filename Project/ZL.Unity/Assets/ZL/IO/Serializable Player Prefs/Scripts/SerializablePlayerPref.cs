using System;

using UnityEngine;

using ZL.CS.Collections;

namespace ZL.Unity.IO
{
    public abstract class SerializablePlayerPref<TValue> : PlayerPrefs, IKeyValuePair<string, TValue>
    {
        [SerializeField]

        private string key;

        public string Key
        {
            get => key;

            set
            {
                if (!key.IsNullOrEmpty())
                {
                    throw new InvalidOperationException("'Key' is already set and cannot be changed.");
                }

                key = value;
            }
        }

        [SerializeField]

        private TValue value;

        public TValue Value
        {
            get => value;

            set
            {
                this.value = value;

                OnValueChangedAction?.Invoke(value);
            }
        }

        public event Action<TValue> OnValueChangedAction;

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