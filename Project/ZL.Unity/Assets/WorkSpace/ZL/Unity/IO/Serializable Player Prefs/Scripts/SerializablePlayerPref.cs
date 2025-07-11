using System;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.IO
{
    public abstract class SerializablePlayerPref<TValue> : PlayerPrefs, IKeyValuePair<string, TValue>
    {
        [ReadOnlyWhenPlayMode]

        [UsingCustomProperty]

        [SerializeField]

        protected string key = "";

        public string Key
        {
            get => key;

            set => key = value;
        }

        [SerializeField]

        protected TValue value;

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

        public SerializablePlayerPref()
        {

        }

        public SerializablePlayerPref(string key, TValue value)
        {
            this.key = key;

            this.value = value;
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