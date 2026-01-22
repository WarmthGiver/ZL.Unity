using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    public static class HandlesEx
    {
        [Conditional("UNITY_EDITOR")]

        public static void SetColor(Color color)
        {
            #if UNITY_EDITOR

            Handles.color = color;

            #endif
        }

        [Conditional("UNITY_EDITOR")]

        public static void SetMatrix(Matrix4x4 matrix)
        {
            #if UNITY_EDITOR

            Handles.matrix = matrix;

            #endif
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawWireSector(Vector3 center, float angle, float radius)
        {
            #if UNITY_EDITOR

            var from = Quaternion.Euler(0f, -angle * 0.5f, 0f) * Vector3.forward;

            var to = Quaternion.Euler(0f, angle * 0.5f, 0f) * Vector3.forward;

            Handles.DrawWireArc(center, Vector3.up, from, angle, radius);

            Handles.DrawLine(center, center + from * radius);

            Handles.DrawLine(center, center + to * radius);

            #endif
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawSector(Vector3 center, float angle, float radius)
        {
            #if UNITY_EDITOR

            var from = Quaternion.Euler(0f, -angle * 0.5f, 0f) * Vector3.forward;

            Handles.DrawSolidArc(center, Vector3.up, from, angle, radius);

            #endif
        }
    }
}