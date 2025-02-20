using UnityEngine;

namespace ZL.CS.Unity.Phys
{
    [ExecuteInEditMode]

    public abstract class CheckShape : MonoBehaviour
    {
        [Space]

        [SerializeField]

        protected LayerMask layerMask = 0;

        [SerializeField]

        protected QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

#if UNITY_EDITOR

        [Space]

        [SerializeField]

        protected bool drawGizmo = true;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen(nameof(drawGizmo), false)]

        private Color defaultGizmoColor = new(1f, 0f, 0f, 0.5f);

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen(nameof(drawGizmo), false)]

        private Color collidedGizmoColor = new(0f, 1f, 0f, 0.5f);

        private void OnDrawGizmosSelected()
        {
            if (drawGizmo == true)
            {
                if (Check() == true)
                {
                    Gizmos.color = collidedGizmoColor;
                }

                else
                {
                    Gizmos.color = defaultGizmoColor;
                }

                DrawGizmo();
            }
        }

        protected abstract void DrawGizmo();

#endif

        public abstract bool Check();
    }
}