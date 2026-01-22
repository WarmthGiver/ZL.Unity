using System;

using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using UnityObject = UnityEngine.Object;

namespace ZL.Unity
{
    public static partial class FixedUndo
    {
        #if UNITY_EDITOR

        public static T AddComponent<T>(GameObject gameObject) where T : Component
        {
            return Undo.AddComponent(gameObject, typeof(T)) as T;
        }

        public static Component AddComponent(GameObject gameObject, Type type)
        {
            return Undo.AddComponent(gameObject, type);
        }

        #endif

        [Conditional("UNITY_EDITOR")]

        public static void RegisterCreatedObjectUndo(UnityObject objectToUndo, string name)
        {
            #if UNITY_EDITOR

            if (EditorApplication.isPlaying == true)
            {
                return;
            }

            Undo.RegisterCreatedObjectUndo(objectToUndo, name);

            #endif
        }

        [Conditional("UNITY_EDITOR")]

        public static void RecordObject(UnityObject objectToUndo, string name)
        {
            #if UNITY_EDITOR

            if (EditorApplication.isPlaying == true)
            {
                return;
            }

            Undo.RecordObject(objectToUndo, name);

            #endif
        }
    }
}