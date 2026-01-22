using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Debugging/Box Gizmo Drawer")]

    public sealed class BoxGizmoDrawer : GizmoDrawer
    {
        #if UNITY_EDITOR

        [SerializeField]

        private Vector3 _size = Vector3.one;

        public Vector3 Size
        {
            get => _size;

            set => _size = value;
        }

        protected override void DrawWireGizmos()
        {
            Gizmos.DrawWireCube(Center, Size);
        }

        protected override void DrawGizmos()
        {
            Gizmos.DrawCube(Center, Size);
        }

        #endif
    }

    public static class BoxGizmoDrawerEx
    {
        [Conditional("UNITY_EDITOR")]

        public static void SetSize(this BoxGizmoDrawer instance, Vector3 size)
        {
            #if UNITY_EDITOR

            if (instance != null)
            {
                instance.Size = size;
            }

            #endif
        }
    }
}