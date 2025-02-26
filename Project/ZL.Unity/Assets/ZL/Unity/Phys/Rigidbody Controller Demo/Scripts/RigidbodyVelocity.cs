#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.DebuggingTools
{
    [AddComponentMenu("ZL/Debugging/Rigidbody Debugger")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody))]

    public sealed class RigidbodyVelocity : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

#pragma warning disable CS0108

        private Rigidbody rigidbody;

#pragma warning restore CS0108

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        private Vector3 velocity = Vector3.zero;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [AddIndent(1)]

        [Alias("Megnitude")]

        private float velocityMagnitude = 0f;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        private Vector3 angularVelocity = Vector3.zero;

        [Space]

        [SerializeField]

        private bool drawVelocity = true;

        private void OnDrawGizmosSelected()
        {
            if (drawVelocity == true)
            {
                Gizmos.color = velocity.ToColor(false);

                Gizmos.DrawLine(transform.position, transform.position + velocity);
            }
        }

        private void Reset()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
            }
        }

        private void OnValidate()
        {
            if (rigidbody.velocity != velocity)
            {
                rigidbody.velocity = velocity;
            }

            velocityMagnitude = velocity.magnitude;

            if (rigidbody.angularVelocity != angularVelocity)
            {
                rigidbody.angularVelocity = angularVelocity;
            }
        }

        private void FixedUpdate()
        {
            velocity = rigidbody.velocity;

            velocityMagnitude = velocity.magnitude;

            angularVelocity = rigidbody.angularVelocity;
        }

        private void Awake()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();

                velocity = rigidbody.velocity;

                angularVelocity = rigidbody.angularVelocity;
            }
        }
    }
}

#endif