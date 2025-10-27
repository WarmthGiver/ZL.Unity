#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] ���! �� ���� ��Ҵ� ���� ����� �������� ���Ǹ� ���忡�� ���ܵ˴ϴ�.<br/>
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