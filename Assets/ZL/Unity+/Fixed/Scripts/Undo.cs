using System.Diagnostics;

using UnityEngine;

#if UNITY_EDITOR

using Base = UnityEditor.Undo;

#endif

namespace ZL.Fixed
{
    public static class Undo
    {
        [Conditional("UNITY_EDITOR")]

        public static void RegisterCreatedObjectUndo(Object objectToUndo, string name)
        {
#if UNITY_EDITOR

            Base.RegisterCreatedObjectUndo(objectToUndo, name);

#endif
        }

        [Conditional("UNITY_EDITOR")]

        public static void RecordObject(Object objectToUndo, string name)
        {
#if UNITY_EDITOR

            Base.RecordObject(objectToUndo, name);

#endif
        }
    }
}