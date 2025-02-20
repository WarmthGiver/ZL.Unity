using UnityEngine;

namespace ZL.CS.Unity.Phys
{
    [AddComponentMenu("ZL/Unity/Phys/Rigidbody Controller")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody))]

    public sealed class RigidbodyController : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private new Rigidbody rigidbody;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private Vector3 gravity = Vector3.zero;

        [SerializeField]

        [UsingCustomProperty]

        private Vector3 velocity = Vector3.zero;

        [Space]

        [SerializeField]

        private Transform gravityTarget;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen("gravityTarget", null, false)]

        [Margin]

        private bool useCustomGravity = true;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen("gravityTarget", null, false)]

        [ToggleWhen("useCustomGravity", false)]

        [Alias("Gravity Direction")]

        private Vector3 customGravityDirection = new(0f, -1f, 0f);

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen("gravityTarget", null, false)]

        [ToggleWhen("useCustomGravity", false)]

        [Alias("Gravity Scale")]

        private float customGravityStrength = 9.81f;

        [Space]

        [SerializeField]

        private bool standUpright = true;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen("standUpright", false)]

        [Alias("Using Slerp")]

        private bool usingSlerp_StandUpright = true;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleWhen("standUpright", false)]

        [Alias("Slerp Speed")]

        private float slerpSpeed_StandUpright = 1f;

        private void Reset()
        {
            rigidbody = GetComponent<Rigidbody>();

            rigidbody.useGravity = false;
        }

        private void OnValidate()
        {
            rigidbody.drag = 0.2f;

            rigidbody.velocity = velocity;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            if (gravityTarget != null)
            {
                Gizmos.DrawLine(transform.position, gravityTarget.position);
            }

            else if (useCustomGravity == true)
            {
                Gizmos.DrawLine(transform.position, transform.position + customGravityDirection * 1000f);
            }

            else
            {
                Gizmos.DrawLine(transform.position, transform.position + Physics.gravity.normalized * 1000f);
            }
        }

        private void FixedUpdate()
        {
            Vector3 gravityDirection;

            if (gravityTarget != null)
            {
                gravityDirection = (transform.position - gravityTarget.position).normalized;

                gravity = gravityDirection * -9.81f;
            }

            else if (useCustomGravity == true)
            {
                gravityDirection = -customGravityDirection;

                gravity = gravityDirection * -customGravityStrength;
            }

            else
            {
                gravityDirection = Physics.gravity.normalized;

                gravity = Physics.gravity;
            }

            if (standUpright == true)
            {
                var uprightRotation = Quaternion.FromToRotation(-transform.up, -gravityDirection) * transform.rotation;

                if (usingSlerp_StandUpright == true)
                {
                    uprightRotation = Quaternion.Slerp(transform.rotation, uprightRotation, slerpSpeed_StandUpright * Time.fixedDeltaTime);
                }

                transform.rotation = uprightRotation;
            }

            rigidbody.AddForce(gravity);

            velocity = rigidbody.velocity;
        }
    }
}