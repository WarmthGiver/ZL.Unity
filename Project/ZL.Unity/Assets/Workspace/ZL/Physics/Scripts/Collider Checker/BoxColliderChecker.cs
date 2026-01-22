using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Physics/Box Collider Checker")]

    public sealed class BoxColliderChecker : ColliderChecker
    {
        [Space]

        [GetComponent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private BoxCollider boxCollider;

        [GetComponent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private BoxGizmoDrawer boxGizmoDrawer;

        [Space]

        [SerializeField]

        private Vector3 _halfExtents = Vector3Ex.Half;

        public Vector3 HalfExtents
        {
            set
            {
                if (_halfExtents == value)
                {
                    return;
                }

                _halfExtents = value;

                oldScale = Vector3.one;

                finalHalfExtents = _halfExtents;

                var size = _halfExtents * 2f;

                if (boxCollider != null)
                {
                    boxCollider.size = size;
                }

                boxGizmoDrawer.SetSize(size);
            }
        }

        private Vector3 oldScale = Vector3.one;

        private Vector3 finalHalfExtents;

        private void OnValidate()
        {
            HalfExtents = _halfExtents;
        }

        private void Awake()
        {
            finalHalfExtents = _halfExtents;
        }

        public override bool Check()
        {
            Refresh();

            return Physics.CheckBox(transform.position, finalHalfExtents, transform.rotation, layer, triggerInteraction);
        }

        public override int Overlap(Collider[] results)
        {
            Refresh();

            return Physics.OverlapBoxNonAlloc(transform.position, finalHalfExtents, results, transform.rotation, layer, triggerInteraction);
        }

        private void Refresh()
        {
            var scale = transform.lossyScale;

            if (oldScale != scale)
            {
                oldScale = scale;

                finalHalfExtents = Vector3.Scale(_halfExtents, scale);
            }
        }
    }
}