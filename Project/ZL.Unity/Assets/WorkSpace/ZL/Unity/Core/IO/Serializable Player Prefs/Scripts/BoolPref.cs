using System;

namespace ZL.Unity.IO
{
    [Serializable]

    public sealed class BoolPref : SerializablePlayerPref<bool>
    {
        public BoolPref() { }

        public BoolPref(string key, bool value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetInt(Key) != 0;
        }

        public override void SaveValue()
        {
            SetInt(Key, Value ? 1 : 0);
        }
    }
}