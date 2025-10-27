using System;

namespace ZL.Unity
{
    [Serializable]

    public sealed class IntPref : SerializablePlayerPref<int>
    {
        public IntPref() { }

        public IntPref(string key, int value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetInt(Key);
        }

        public override void SaveValue()
        {
            SetInt(Key, Value);
        }
    }
}