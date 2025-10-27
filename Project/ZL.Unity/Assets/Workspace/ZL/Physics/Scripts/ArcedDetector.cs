#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Arced Detector")]

    public sealed class ArcedDetector : MonoBehaviour
    {
        [Space]

        [Min(0f)]

        [SerializeField]

        private float radius = 1f;

        public float Radius
        {
            set => radius = value;
        }

        [Min(0f)]

        [SerializeField]

        private float angle = 60f;

        public float Angle
        {
            set => angle = value;
        }

        #if UNITY_EDITOR

        [Space]

        [Line(Margin = 0)]

        [Text("<b>Debugging</b>", FontSize = 16)]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private bool drawGizmo = true;

        [ToggleIf(nameof(drawGizmo), false)]

        [AddIndent(1)]

        [Alias("Is Wire")]

        [UsingCustomProperty]

        [SerializeField]

        private bool isWireGizmo = false;

        [ToggleIf(nameof(drawGizmo), false)]

        [AddIndent(1)]

        [Alias("Default Color")]

        [UsingCustomProperty]

        [SerializeField]

        private Color defaultGizmoColor = new(1f, 0f, 0f, 0.25f);

        private void OnDrawGizmosSelected()
        {
            if (enabled == false)
            {
                return;
            }

            if (drawGizmo == false)
            {
                return;
            }

            Handles.color = defaultGizmoColor;

            var center = transform.position;

            var radius = this.radius * transform.lossyScale.GetMaxAxis();

            var start = Quaternion.Euler(0f, -angle * 0.5f, 0f) * transform.forward;

            if (isWireGizmo == true)
            {
                var end = Quaternion.Euler(0f, angle * 0.5f, 0f) * transform.forward;

                Handles.DrawWireArc(center, Vector3.up, start, angle, radius);

                Handles.DrawLine(center, center + start * radius);

                Handles.DrawLine(center, center + end * radius);
            }

            else
            {
                Handles.DrawSolidArc(center, Vector3.up, start, angle, radius);
            }
        }

        #pragma warning disable

        private void Start() { }

        #pragma warning restore

        #endif

        public bool Detect(Transform target)
        {
            if (enabled == false)
            {
                return false;
            }

            Vector3 direction = target.position - transform.position;

            if (direction.magnitude > radius * transform.lossyScale.GetMaxAxis())
            {
                return false;
            }

            float dot = Vector3.Dot(direction.normalized, transform.forward);

            float acos = Mathf.Acos(dot);

            float degree = Mathf.Rad2Deg * acos;

            if (degree > angle * 0.5f)
            {
                return false;
            }

            return true;
        }
    }
}