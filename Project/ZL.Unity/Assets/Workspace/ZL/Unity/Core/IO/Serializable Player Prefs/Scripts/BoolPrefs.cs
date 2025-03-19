using System;

namespace ZL.Unity.IO
{
    [Serializable]

    public sealed class BoolPrefs : SerializablePlayerPrefs<bool>
    {
        public BoolPrefs(string key, bool value) : base(key, value) { }

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