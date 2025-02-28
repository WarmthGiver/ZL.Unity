using UnityEngine;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Collider Check Sphere")]

    [DisallowMultipleComponent]

    public class ColliderCheckSphere : ColliderChecker
    {
        [SerializeField]

        [UsingCustomProperty]

        [Line]

        private float radius = 0.5f;

#if UNITY_EDITOR

        protected override void DrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }

#endif

        public override bool Check()
        {
            return Physics.CheckSphere(transform.position, radius, layerMask, triggerInteraction);
        }
    }
}