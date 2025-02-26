using UnityEngine;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Check Sphere")]

    public class CheckSphere : CheckShape
    {
        [SerializeField]

        private float radius = 0.5f;

#if UNITY_EDITOR

        protected override void DrawGizmo()
        {
            Gizmos.DrawSphere(transform.position, radius);
        }

#endif

        public override bool Check()
        {
            return Physics.CheckSphere(transform.position, radius, layerMask, triggerInteraction);
        }
    }
}