using UnityEngine;

namespace ZL.Unity
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 오직 디버깅 목적으로 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Mesh Gizmo Drawer")]

    public sealed class MeshGizmoDrawer : GizmoDrawer
    {
        #if UNITY_EDITOR

        [SerializeField]

        private Mesh mesh = null;

        public Mesh Mesh
        {
            set => mesh = value;
        }

        protected override void DrawWireGizmos()
        {
            Gizmos.DrawWireMesh(mesh);
        }

        protected override void DrawGizmos()
        {
            Gizmos.DrawMesh(mesh);
        }

        #endif
    }
}