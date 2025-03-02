using UnityEngine;

namespace ZL.Unity.Phys
{
    public abstract class ColliderChecker : MonoBehaviour
    {
        [Space]

        [SerializeField]

        protected LayerMask layerMask = 0;

        public LayerMask LayerMask
        {
            get => layerMask;

            set => layerMask = value;
        }

        [SerializeField]

        protected QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

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

        [AddIndent(1)]

        [Alias("Default Color")]

        private Color defaultGizmoColor = new(1f, 0f, 0f, 0.5f);

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(drawGizmo), false)]

        [AddIndent(1)]

        [Alias("Collided Color")]

        private Color collidedGizmoColor = new(0f, 1f, 0f, 0.5f);

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

            DrawGizmos();
        }

        protected abstract void DrawGizmos();

#endif

        public abstract bool Check();
    }
}