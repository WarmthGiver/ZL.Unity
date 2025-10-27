using System;

namespace ZL.Unity
{
    [Serializable]

    public sealed class StringPref : SerializablePlayerPref<string>
    {
        public StringPref() { }

        public StringPref(string key, string value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetString(Key);
        }

        public override void SaveValue()
        {
            SetString(Key, Value);
        }
    }
}