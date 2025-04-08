using UnityEngine;

namespace ZL.Unity.Phys
{
    public abstract class ColliderChecker : MonoBehaviour
    {
        [Space]

        [SerializeField]

        protected LayerMask layerMask = ~0;

        public LayerMask LayerMask
        {
            get => layerMask;

            set => layerMask = value;
        }

        [SerializeField]

        protected QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal;

#if UNITY_EDITOR

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Debugging Options</b>", FontSize = 16)]

        [Margin]

        protected bool drawGizmo = true;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(drawGizmo), false)]

        protected bool wireGizmo = false;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(drawGizmo), false)]

        [AddIndent(1)]

        [Alias("Default Color")]

        private Color defaultGizmoColor = new(0f, 1f, 0f, 0.5f);

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(drawGizmo), false)]

        [AddIndent(1)]

        [Alias("Collided Color")]

        private Color collidedGizmoColor = new(1f, 0f, 0f, 0.5f);

        private void OnDrawGizmosSelected()
        {
            if (drawGizmo == false)
            {
                return;
            }

            if (Check() == true)
            {
                Gizmos.color = collidedGizmoColor;
            }

            else
            {
                Gizmos.color = defaultGizmoColor;
            }

            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new(2f, 2f, 2f));

            DrawGizmos();
        }
        
        protected abstract void DrawGizmos();

#endif

        public abstract bool Check();
    }
}