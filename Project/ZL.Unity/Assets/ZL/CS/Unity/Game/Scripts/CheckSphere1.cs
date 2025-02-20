using UnityEngine;

namespace ZL.CS.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Check Sphere")]

    public class CheckSphere : CheckShape
    {
        [SerializeField]

        private float radius = 0.5f;

        protected override void DrawGizmo()
        {
            Gizmos.DrawSphere(transform.position, radius);
        }

        public override bool Check()
        {
            return Physics.CheckSphere(transform.position, radius, layerMask, triggerInteraction);
        }
    }
}