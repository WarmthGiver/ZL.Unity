using System;

namespace ZL.Unity
{
    [Serializable]

    public sealed class IntPref : PlayerPref<int>
    {
        public IntPref(string key, int value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetInt(key);
        }

        public override void SaveValue()
        {
            SetInt(key, value);
        }
    }
}