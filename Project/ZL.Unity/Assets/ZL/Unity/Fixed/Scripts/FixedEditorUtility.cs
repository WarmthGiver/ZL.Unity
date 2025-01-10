using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    public static partial class FixedEditorUtility
    {
        [Conditional("UNITY_EDITOR")]

        public static void SetDirty(Object target)
        {
#if UNITY_EDITOR

            EditorUtility.SetDirty(target);

#endif
        }
    }
}