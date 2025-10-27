#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] ���! �� ���� ��Ҵ� ���� ����� �������� ���Ǹ� ���忡�� ���ܵ˴ϴ�.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Wire Sphere Gizmo Drawer")]

    public sealed class WireSphereGizmoDrawer : SphereGizmoDrawer
    {
        protected override void DrawGizmo()
        {
            Gizmos.DrawWireSphere(center, radius);
        }
    }
}

#endif