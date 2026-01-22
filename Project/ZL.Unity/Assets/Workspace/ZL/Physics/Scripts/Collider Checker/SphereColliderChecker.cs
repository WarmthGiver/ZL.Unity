using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Physics/Sphere Collider Checker")]

    public sealed class SphereColliderChecker : ColliderChecker
    {
        [Space]

        [GetComponent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private SphereCollider sphereCollider;

        [GetComponent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private SphereGizmoDrawer sphereGizmoDrawer;

        [Space]

        [SerializeField]

        private float _radius = 0.5f;

        public float Radius
        {
            get => _radius;

            set
            {
                if (_radius == value)
                {
                    return;
                }

                _radius = value;

                oldScale = 1f;

                finalRadius = _radius;

                if (sphereCollider != null)
                {
                    sphereCollider.radius = _radius;
                }

                sphereGizmoDrawer.SetRadius(_radius);
            }
        }

        private float oldScale = 1f;

        private float finalRadius;

        private void OnValidate()
        {
            Radius = _radius;
        }

        private void Awake()
        {
            finalRadius = _radius;
        }

        public override bool Check()
        {
            Refresh();

            return Physics.CheckSphere(transform.position, finalRadius, layer, triggerInteraction);
        }

        public override int Overlap(Collider[] results)
        {
            Refresh();

            return Physics.OverlapSphereNonAlloc(transform.position, finalRadius, results, layer, triggerInteraction);
        }

        private void Refresh()
        {
            float scale = transform.lossyScale.GetMaxAxis();

            if (oldScale != scale)
            {
                oldScale = scale;

                finalRadius = Radius * scale;
            }
        }
    }
}