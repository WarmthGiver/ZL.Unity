#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] ���! �� ���� ��Ҵ� ���� ����� �������� ���Ǹ� ���忡�� ���ܵ˴ϴ�.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Box Gizmo Drawer")]

    public class BoxGizmoDrawer : GizmoDrawer
    {
        [SerializeField]

        protected Vector3 size = Vector3.one;

        protected override void DrawGizmo()
        {
            Gizmos.DrawCube(center, size);
        }
    }
}

#endif