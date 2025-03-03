using UnityEngine;

using ZL.CS;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Unity/Phys/Rigidbody Character Controller")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CapsuleCollider))]

    [RequireComponent(typeof(Rigidbody))]

    [RequireComponent(typeof(GravityController))]

    public class RigidbodyCharacterController : MonoBehaviour
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

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private GravityController gravityController;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        private bool rotateTransformUpright = true;

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

        private float speedForRotateTransformUpright = 10f;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Grounding</b>", FontSize = 16)]

        [Margin]

        protected LayerMask groundLayerMask = 0;

        public LayerMask GroundLayerMask
        {
            get => groundLayerMask;

            set => groundLayerMask = value;
        }

        [SerializeField]

        private float groundSlopeThreshold = 45;

        public float GroundedSlopeThreshold
        {
            get => groundSlopeThreshold;

            set => groundSlopeThreshold = value;
        }

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        protected bool isGrounded = false;

        private int contactUphillsCount;

        private Vector3 contactUphillsNormal;

        private int contactDownhillsCount;

        private Vector3 contactDownhillsNormal;

        private int contactWallsCount;

        private Vector3 contactWallsNormal;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Controls</b>", FontSize = 16)]

        [Margin]

        protected Vector3 movementDirection = Vector3.zero;

        public Vector3 MovementDirection
        {
            get => movementDirection;

            set => movementDirection = value;
        }

        [SerializeField]

        protected float movementSpeed = 10f;

        public float MovementSpeed
        {
            get => movementSpeed;

            set => movementSpeed = value;
        }

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        protected Vector3 jumpDirection = Vector3.zero;

        public Vector3 JumpDirection
        {
            get => jumpDirection;

            set => jumpDirection = value;
        }

        [SerializeField]

        private float jumpSpeed = 10f;

        public float JumpSpeed
        {
            get => jumpSpeed;

            set => jumpSpeed = value;
        }

#if UNITY_EDITOR

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Line(Margin = 0)]

        [Text("<b>Debugging</b>", FontSize = 16)]

        [Margin]

        private bool drawMovementForceGizmo = true;

        [SerializeField]

        [UsingCustomProperty]

        private bool drawCollisionContactGizmo = true;

#endif

        private void FixedUpdate()
        {
            var uprightRotation = Quaternion.FromToRotation(-transform.up, gravityController.GravityDirection) * transform.rotation;

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

            var direction = transform.rotation * movementDirection;

            if (contactUphillsCount > 0)
            {
                direction = Vector3.ProjectOnPlane(direction, contactUphillsNormal / contactUphillsCount);
            }

            else if (contactDownhillsCount > 0)
            {
                direction = Vector3.ProjectOnPlane(direction, contactDownhillsNormal / contactDownhillsCount);
            }

            else if (contactWallsCount > 0)
            {
                direction = Vector3.ProjectOnPlane(direction, contactWallsNormal / contactWallsCount);
            }

            if (drawMovementForceGizmo == true)
            {
                Debug.DrawLine(transform.position, transform.position + movementSpeed * direction, movementDirection.ToColor());
            }

            rigidbody.MovePosition(transform.position + movementSpeed * Time.fixedDeltaTime * direction);

            rigidbody.AddForce(transform.rotation * jumpDirection * jumpSpeed, ForceMode.VelocityChange);

            jumpDirection = Vector3.zero;

            isGrounded = false;

            contactUphillsCount = 0;

            contactUphillsNormal = Vector3.zero;

            contactDownhillsCount = 0;

            contactDownhillsNormal = Vector3.zero;

            contactWallsCount = 0;

            contactWallsNormal = Vector3.zero;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (groundLayerMask.Contains(collision.gameObject.layer))
            {
                int contactsCount = collision.contacts.Length;

                foreach (var contact in collision.contacts)
                {
#if UNITY_EDITOR

                    if (drawCollisionContactGizmo == true)
                    {
                        Debug.DrawLine(transform.position, contact.point, Color.red, Time.fixedDeltaTime);
                    }

#endif

                    float bottomDotContact = Vector3.Dot(contact.point - transform.position, transform.up);

                    if (bottomDotContact > 0f)
                    {
                        float wallDotDirection = Vector3.Dot(transform.rotation * movementDirection, contact.normal);

                        if (wallDotDirection < 0f)
                        {
                            ++contactWallsCount;

                            contactWallsNormal += contact.normal;
                        }

                        continue;
                    }

                    float groundAngle = Vector3.Angle(transform.up, contact.normal).Round(2);

                    if (groundAngle > groundSlopeThreshold)
                    {
                        ++contactWallsCount;

                        contactWallsNormal += contact.normal;

                        continue;
                    }

                    isGrounded = true;

                    float groundDotDirection = Vector3.Dot(transform.rotation * movementDirection, contact.normal).Round(2);

                    if (groundDotDirection < -0.1f)
                    {
                        ++contactUphillsCount;

                        contactUphillsNormal += contact.normal;
                    }

                    else
                    {
                        ++contactDownhillsCount;

                        contactDownhillsNormal += contact.normal;
                    }
                }
            }
        }

        public void RotateUpright()
        {
            transform.rotation = Quaternion.FromToRotation(-transform.up, gravityController.GravityDirection) * transform.rotation;
        }
    }
}