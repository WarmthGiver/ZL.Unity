#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] ���! �� ���� ��Ҵ� ���� ����� �������� ���Ǹ� ���忡�� ���ܵ˴ϴ�.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Wire Box Gizmo Drawer")]

    public sealed class WirwBoxGizmoDrawer : BoxGizmoDrawer
    {
        protected override void DrawGizmo()
        {
            Gizmos.DrawWireCube(center, size);
        }
    }
}

#endif