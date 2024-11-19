#if UNITY_EDITOR

using Base = UnityEditor.EditorApplication;

namespace ZL.Fixed
{
    public static class EditorApplication
	{
        public static Base.CallbackFunction update
        {
            get => Base.update;

            set => Base.update = value;
        }

        public static bool isPlaying
        {
            get => Base.isPlaying;

            set => Base.isPlaying = value;
        }
    }
}

#endif