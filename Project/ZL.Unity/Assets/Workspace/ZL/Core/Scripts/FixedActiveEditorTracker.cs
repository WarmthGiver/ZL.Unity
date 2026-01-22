#if UNITY_EDITOR

using UnityEditor;

using UnityEditor.Callbacks;

namespace ZL.Unity
{
    public static partial class FixedActiveEditorTracker
    {
        [DidReloadScripts]

        public static void ForceRebuild()
        {
            EditorApplication.delayCall += () =>
            {
                ActiveEditorTracker.sharedTracker.ForceRebuild();
            };
        }
    }
}

#endif