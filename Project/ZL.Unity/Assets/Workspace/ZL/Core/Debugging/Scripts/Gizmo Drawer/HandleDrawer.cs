#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    public abstract class HandleDrawer : GizmoDrawer
    {
        #if UNITY_EDITOR

        protected override void SetupGizmos()
        {
            Handles.color = Color;

            Handles.matrix = Matrix;
        }

        #endif
    }
}