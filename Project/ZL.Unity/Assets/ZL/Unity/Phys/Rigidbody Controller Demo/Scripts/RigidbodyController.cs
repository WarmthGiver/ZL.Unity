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

#pragma warning disable CS0108

        private Rigidbody rigidbody;

        public Rigidbody Rigidbody => rigidbody;

#pragma warning restore CS0108

#if UNITY_EDITOR

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [WarningBox("Warning! These fields are only valid in the Unity Editor.")]

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

        #endif

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

        public float GravityScale
        {
            get => gravityScale;

            set => gravityScale = value;
        }

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

        public Vector3 GravityDirection => gravityDirection;

        private Vector3 oldGravityDirection;

        private Vector3 gravityForce = Vector3.zero;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Controls</b>", FontSize = 16)]

        [Margin]

        private Vector3 moveForce = Vector3.zero;

        public Vector3 MoveForce
        {
            get => moveForce;

            set => moveForce = value;
        }

        private Vector3 accelerationForce = Vector3.zero;

        public Vector3 AccelerationForce => accelerationForce;

        [SerializeField]

        [UsingCustomProperty]

        private Vector3 impulseForce = Vector3.zero;

        public Vector3 ImpulseForce
        {
            get => impulseForce;

            set => impulseForce = value;
        }

#if UNITY_EDITOR

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Debugging Options</b>", FontSize = 16)]

        [Margin]

        private bool drawVelocityGizmo = true;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Alias("Draw Gravity Direction")]

        private bool drawGravityDirectionGizmo = true;

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent(1)]

        [Alias("Length")]

        private float gravityDirectionGizmoLength = 1000f;

        private void OnDrawGizmosSelected()
        {
            if (drawVelocityGizmo == true)
            {
                Gizmos.color = velocity.ToColor();

                Gizmos.DrawLine(transform.position, transform.position + velocity);
            }

            if (drawGravityDirectionGizmo == true && useGravity == true)
            {
                Vector3 gravityDirection;

                if (useCustomGravity == true)
                {
                    gravityDirection = customGravityDirection;
                }

                else if (gravityGenerator != null)
                {
                    gravityDirection = gravityGenerator.transform.position - transform.position;
                }

                else
                {
                    gravityDirection = Physics.gravity;
                }

                gravityDirection = gravityDirection.normalized;

                Gizmos.color = gravityDirection.ToColor();

                Gizmos.DrawLine(transform.position, transform.position + gravityDirection * gravityDirectionGizmoLength);
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

        private void Awake()
        {
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();

                velocity = rigidbody.velocity;

                angularVelocity = rigidbody.angularVelocity;
            }
        }

#endif

        private void FixedUpdate()
        {
            accelerationForce = Vector3.zero;

            oldGravityDirection = gravityDirection;

            if (useGravity == false)// || gravityScale == 0f)
            {
                gravityDirection = Vector3.zero;

                gravityForce = Vector3.zero;
            }

            else
            {
                var gravityScale = this.gravityScale;

                if (useCustomGravity == true)
                {
                    gravityDirection = customGravityDirection.normalized;

                    gravityForce = customGravityStrength * gravityScale * gravityDirection;
                }

                else if (gravityGenerator != null)
                {
                    gravityDirection = gravityGenerator.GetGravityDirection(transform.position).normalized;

                    gravityForce = gravityGenerator.GravityStrength * gravityScale * gravityDirection;
                }

                else
                {
                    gravityDirection = Physics.gravity.normalized;

                    gravityForce = Physics.gravity * gravityScale;
                }
            }

            if (gravityDirection != Vector3.zero)
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

            if (moveForce != Vector3.zero)
            {
                accelerationForce += transform.rotation * moveForce;
            }

            if (accelerationForce != Vector3.zero)
            {
                rigidbody.AddForce(accelerationForce, ForceMode.Acceleration);
            }

            if (impulseForce != Vector3.zero)
            {
                rigidbody.AddForce(transform.rotation * impulseForce, ForceMode.VelocityChange);

                impulseForce = Vector3.zero;
            }

#if UNITY_EDITOR

            velocity = rigidbody.velocity;

            velocityMagnitude = velocity.magnitude;

            angularVelocity = rigidbody.angularVelocity;

#endif
        }

        private void OnCollisionStay(Collision collision)
        {
            foreach (var contactPoint in collision.contacts)
            {
                
            }
        }

        public void RotateUpright()
        {
            transform.rotation = Quaternion.FromToRotation(-transform.up, gravityDirection) * transform.rotation;
        }
    }
}