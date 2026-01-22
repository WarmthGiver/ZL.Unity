#if UNITY_EDITOR

using static UnityEditor.EditorApplication;

#endif

using System.Diagnostics;

public static partial class FixedEditorApplication
{
    [Conditional("UNITY_EDITOR")]

    public static void DelayedCall(CallbackFunction action)
    {
        #if UNITY_EDITOR

        delayCall += action;

        #endif
    }
}
