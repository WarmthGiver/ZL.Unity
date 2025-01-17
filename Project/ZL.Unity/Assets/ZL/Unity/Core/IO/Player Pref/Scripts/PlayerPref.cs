using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.IO
{
    public abstract class PlayerPref<T> : PlayerPrefs, IKeyValueContainer<string, T>
    {
        [SerializeField]

        protected string key;

        public string Key => key;

        [SerializeField]

        protected T value;

        public T Value
        {
            get => value;

            set => this.value = value;
        }

        public PlayerPref(string key, T value)
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

        public abstract void SaveValue();

        public override string ToString()
        {
            return $"[{key}, {value}]";
        }
    }
}