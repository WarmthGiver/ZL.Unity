using System.Diagnostics;

using UnityEngine;

using ZL.CS;

namespace ZL.Unity
{
    public static class GizmosEx
    {
        [Conditional("UNITY_EDITOR")]

        public static void DrawPolygon(Vector3 center, float circumradius, int numSides)
        {
            #if UNITY_EDITOR

            var prevPoint = center + new Vector3(circumradius, 0f, 0f);

            for (int i = 1; i <= numSides; ++i)
            {
                float angle = MathFEx.PI2 * i / numSides;

                float x = Mathf.Cos(angle) * circumradius;

                float z = Mathf.Sin(angle) * circumradius;

                var nextPoint = center + new Vector3(x, 0f, z);

                Gizmos.DrawLine(prevPoint, nextPoint);

                prevPoint = nextPoint;
            }

            #endif
        }
    }
}