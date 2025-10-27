#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 오직 디버깅 목적으로 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Sphere Gizmo Drawer")]

    public class SphereGizmoDrawer : GizmoDrawer
    {
        [SerializeField]

        protected float radius = 0.5f;

        protected override void DrawGizmo()
        {
            Gizmos.DrawSphere(center, radius);
        }
    }
}

#endif