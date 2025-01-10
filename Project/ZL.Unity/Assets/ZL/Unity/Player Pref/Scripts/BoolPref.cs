using System;

namespace ZL.Unity
{
    [Serializable]

    public sealed class BoolPref : PlayerPref<bool>
    {
        public BoolPref(string key, bool value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetInt(key) != 0;
        }

        public override void SaveValue()
        {
            SetInt(key, value ? 1 : 0);
        }
    }
}