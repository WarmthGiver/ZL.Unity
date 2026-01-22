using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Debugging/Sphere Gizmo Drawer")]

    public sealed class SphereGizmoDrawer : GizmoDrawer
    {
        #if UNITY_EDITOR

        [SerializeField]

        private float _radius = 0.5f;

        public float Radius
        {
            get => _radius;

            set => _radius = value;
        }

        protected override Matrix4x4 Matrix
        {
            get => Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale.UniformMax());
        }

        protected override void DrawWireGizmos()
        {
            Gizmos.DrawWireSphere(Center, Radius);
        }

        protected override void DrawGizmos()
        {
            Gizmos.DrawSphere(Center, Radius);
        }

        #endif
    }

    public static class SphereGizmoEx
    {
        [Conditional("UNITY_EDITOR")]

        public static void SetRadius(this SphereGizmoDrawer instance, float radius)
        {
            #if UNITY_EDITOR

            if (instance != null)
            {
                instance.Radius = radius;
            }

            #endif
        }
    }
}