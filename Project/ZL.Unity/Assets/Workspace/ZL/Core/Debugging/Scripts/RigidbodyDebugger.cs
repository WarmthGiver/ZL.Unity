#pragma warning disable

#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Rigidbody Debugger")]

    public sealed class RigidbodyDebugger : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Toggle(true)]

        [SerializeField]

        private Transform transform;

        [Space]

        [WarningBox("[ENG] Warning! This component is for debugging purposes only and is excluded from the build.")]

        [WarningBox("[KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.")]

        [Margin]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Rigidbody rigidbody = null;

        [Space]

        [UsingCustomProperty]

        [SerializeField]

        private Vector3 velocity = Vector3.zero;

        [ReadOnly(true)]

        [AddIndent(1)]

        [Alias("Megnitude")]

        [UsingCustomProperty]

        [SerializeField]

        private float velocityMagnitude = 0f;

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