#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] ���! �� ���� ��Ҵ� ����� �������θ� ���Ǹ� ���忡�� ���ܵ˴ϴ�.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Rigidbody Debugger")]

    public sealed class RigidbodyDebugger : MonoBehaviour
    {
        [Space]

        [WarningBox("[ENG] Warning! This component is for debugging purposes only and is excluded from the build.")]

        [WarningBox("[KOR] ���! �� ���� ��Ҵ� ����� �������θ� ���Ǹ� ���忡�� ���ܵ˴ϴ�.")]

        [Margin]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        #pragma warning disable

        private Rigidbody rigidbody = null;

        #pragma warning restore

        [Space]

        [UsingCustomProperty]

        [SerializeField]

        private Vector3 velocity = Vector3.zero;

        [ReadOnly(true)]

        [AddIndent(1)]

        [Alias("Megnitude")]

        [UsingCustomProperty]

        [SerializeField]

        #pragma warning disable

        private float velocityMagnitude = 0f;

        #pragma warning restore

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        private Vector3 angularVelocity = Vector3.zero;

        [Space]

        [SerializeField]

        private bool drawVelocityGizmo = true;

        private void OnDrawGizmosSelected()
        {
            if (drawVelocityGizmo == true)
            {
                Gizmos.color = velocity.ToColor();

                Gizmos.DrawLine(transform.position, transform.position + velocity);
            }
        }

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                return;
            }

            if (rigidbody.velocity != velocity)
            {
                rigidbody.velocity = velocity;

                velocityMagnitude = velocity.magnitude;
            }

            if (rigidbody.angularVelocity != angularVelocity)
            {
                rigidbody.angularVelocity = angularVelocity;
            }
        }

        private void Awake()
        {
            velocity = rigidbody.velocity;

            angularVelocity = rigidbody.angularVelocity;
        }

        private void FixedUpdate()
        {
            velocity = rigidbody.velocity;

            velocityMagnitude = velocity.magnitude;

            angularVelocity = rigidbody.angularVelocity;
        }
    }
}

#endif