using UnityEngine;

namespace ZL.Unity.Phys
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

        [GetComponent]

#pragma warning disable CS0108

        private Rigidbody rigidbody;

        public Rigidbody Rigidbody => rigidbody;

#pragma warning restore CS0108

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Gravity Options</b>", FontSize = 16)]

        [Margin]

        private bool useGravity = true;

        [Space]

        [SerializeField]

        private bool useCustomGravity = false;

        public bool UseCustomGravity
        {
            get => useCustomGravity;

            set => useCustomGravity = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(useCustomGravity), true)]

        [AddIndent(1)]

        private GravityGenerator gravityGenerator;

        public GravityGenerator GravityGenerator
        {
            get => gravityGenerator;

            set => gravityGenerator = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent(1)]

        [ToggleIf(nameof(useCustomGravity), false)]

        [Alias("Gravity Direction")]

        private Vector3 customGravityDirection = new(0f, -1f, 0f);

        public Vector3 CustomGravityDirection
        {
            get => customGravityDirection;
            
            set => customGravityDirection = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(useCustomGravity), false)]

        [AddIndent(1)]

        [Alias("Gravity Strength")]

        private float customGravityStrength = 9.81f;

        public float CustomGravityStrength
        {
            get => customGravityStrength;

            set => customGravityStrength = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent(1)]

        private float gravityScale = 1f;

        [Space]

        [SerializeField]

        private bool rotateTransformUpright = false;

        public bool RotateTransformUpright
        {
            get => rotateTransformUpright;

            set => rotateTransformUpright = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(rotateTransformUpright), false)]

        [AddIndent(1)]

        [Alias("Use Slerp")]

        private bool useSlerpForRotateTransformUpright = true;

        [SerializeField]

        [UsingCustomProperty]

        [ToggleIf(nameof(rotateTransformUpright), false)]

        [ToggleIf(nameof(useSlerpForRotateTransformUpright), false)]

        [AddIndent(2)]

        [Alias("Speed")]

        [PropertyField]

        [Margin]

        private float speedForRotateTransformUpright = 10f;

        [SerializeField]

        private bool rotateVelocityUpright = true;

        private Vector3 gravityDirection = Vector3.zero;

        private Vector3 oldGravityDirection;

        private Vector3 gravityForce = Vector3.zero;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Controls</b>", FontSize = 16)]

        [Margin]

        private Vector3 moveDirection = Vector3.zero;

        private Vector3 accelerationForce = Vector3.zero;

        [SerializeField]

        [UsingCustomProperty]

        private Vector3 impulseDirection = Vector3.zero;

#if UNITY_EDITOR

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Debugging Options</b>", FontSize = 16)]

        [Margin]

        private bool drawGravityDirection = true;

        private void OnDrawGizmosSelected()
        {
            if (drawGravityDirection == true && useGravity == true)
            {
                Vector3 destination;

                if (useCustomGravity == true)
                {
                    destination = customGravityDirection.normalized * 10000f;
                }

                else if (gravityGenerator != null)
                {
                    destination = gravityGenerator.transform.position;
                }

                else
                {
                    destination = transform.position + Physics.gravity.normalized * 10000f;
                }

                Vector3 direction = destination - transform.position;

                Gizmos.color = direction.ToColor(true);

                Gizmos.DrawLine(transform.position, destination);
            }
        }

#endif

        private void FixedUpdate()
        {
            accelerationForce = Vector3.zero;

            oldGravityDirection = gravityDirection;

            if (useGravity == false || gravityScale == 0f)
            {
                gravityDirection = Vector3.zero;

                gravityForce = Vector3.zero;
            }

            else if (useCustomGravity == true)
            {
                gravityDirection = customGravityDirection;

                gravityForce = customGravityStrength * gravityScale * gravityDirection;
            }

            else if (gravityGenerator != null)
            {
                gravityDirection = -gravityGenerator.GetGravityDirection(transform.position).normalized;

                gravityForce = gravityGenerator.GravityStrength * gravityScale * gravityDirection;
            }

            else
            {
                gravityDirection = Physics.gravity.normalized;

                gravityForce = Physics.gravity * gravityScale;
            }

            if (gravityForce != Vector3.zero)
            {
                var uprightRotation = Quaternion.FromToRotation(-transform.up, gravityDirection) * transform.rotation;

                if (rotateTransformUpright == true)
                {
                    if (useSlerpForRotateTransformUpright == true)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, uprightRotation, speedForRotateTransformUpright * Time.fixedDeltaTime);
                    }

                    else
                    {
                        transform.rotation = uprightRotation;
                    }
                }

                if (rotateVelocityUpright == true)
                {
                    rigidbody.velocity = Quaternion.FromToRotation(oldGravityDirection, gravityDirection) * rigidbody.velocity;
                }

                accelerationForce += gravityForce;
            }

            if (moveDirection != Vector3.zero)
            {
                accelerationForce += transform.rotation * moveDirection;
            }

            if (accelerationForce != Vector3.zero)
            {
                rigidbody.AddForce(accelerationForce, ForceMode.Acceleration);
            }

            if (impulseDirection != Vector3.zero)
            {
                rigidbody.AddForce(transform.rotation * impulseDirection, ForceMode.VelocityChange);

                impulseDirection = Vector3.zero;
            }
        }

        public void Move(Vector3 direction)
        {
            moveDirection = direction;
        }

        public void Impulse(Vector3 direction)
        {
            impulseDirection = direction;
        }

        public void SetRotationUpright()
        {
            transform.rotation = Quaternion.FromToRotation(-transform.up, gravityDirection) * transform.rotation;
        }
    }
}