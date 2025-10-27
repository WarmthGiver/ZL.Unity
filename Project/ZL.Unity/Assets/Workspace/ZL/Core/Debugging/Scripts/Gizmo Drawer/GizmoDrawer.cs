#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    public abstract class GizmoDrawer : MonoBehaviour
    {
        [Space]

        [WarningBox("[ENG] Warning! This component is for debugging purposes only and is excluded from the build.")]

        [WarningBox("[KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.")]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private bool drawOnSelected = true;

        [Space]

        [SerializeField]

        private Color color = new(1f, 0f, 0f, 0.5f);

        [SerializeField]

        protected Vector3 center = Vector3.zero;

        private void OnDrawGizmos()
        {
            if (drawOnSelected == true)
            {
                return;
            }

            SetupGizmo();

            DrawGizmo();
        }

        private void OnDrawGizmosSelected()
        {
            if (drawOnSelected == false)
            {
                return;
            }

            SetupGizmo();

            DrawGizmo();
        }

        protected virtual void SetupGizmo()
        {
            Gizmos.color = color;

            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        }

        protected abstract void DrawGizmo();
    }
}

#endif