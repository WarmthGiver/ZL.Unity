#if UNITY_EDITOR

using UnityEditor;

namespace ZL.Unity
{
    public static class FixedEditorApplication
	{
        public static EditorApplication.CallbackFunction update
        {
            get => EditorApplication.update;

            set => EditorApplication.update = value;
        }

        public static bool isPlaying
        {
            get => EditorApplication.isPlaying;

            set => EditorApplication.isPlaying = value;
        }
    }
}

#endif