using System;

namespace ZL.Unity
{
    [Serializable]

    public sealed class FloatPref : SerializablePlayerPref<float>
    {
        public FloatPref() { }

        public FloatPref(string key, float value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetFloat(Key);
        }

        public override void SaveValue()
        {
            SetFloat(Key, Value);
        }
    }
}