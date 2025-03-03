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

        private CapsuleCollider capsuleCollider;

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

        protected LayerMask groundLayerMask = 0;

        public LayerMask GroundLayerMask
        {
            get => groundLayerMask;

            set => groundLayerMask = value;
        }

        [SerializeField]

        private float groundedAngleThreshold = 45f;

        public float GroundedAngleThreshold
        {
            get => groundedAngleThreshold;

            set => groundedAngleThreshold = value;
        }

#if UNITY_EDITOR

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private float groundAngle = 0f;

#endif

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

        [PropertyField]

        [Margin]

        private float speedForRotateTransformUpright = 10f;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        protected bool isGrounded = false;

        [SerializeField]

        private int contactUphillsCount;

        private Vector3 contactUphillsNormal;

        [SerializeField]

        private int contactDownhillsCount;

        private Vector3 contactDownhillsNormal;

        [SerializeField]

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

        [Text("<b>Debugging Options</b>", FontSize = 16)]

        [Margin]

        private bool drawMovementForce = true;

        [SerializeField]

        [UsingCustomProperty]

        private bool drawCollisionContacts = true;

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

            if (drawMovementForce == true)
            {
                Debug.DrawLine(transform.position, transform.position + movementSpeed * direction, movementDirection.ToColor());
            }

            rigidbody.MovePosition(transform.position + movementSpeed * Time.fixedDeltaTime * direction);

            rigidbody.AddForce(transform.rotation * jumpDirection * jumpSpeed, ForceMode.VelocityChange);

            jumpDirection = Vector3.zero;

            isGrounded = false;

            contactUphillsNormal = Vector3.zero;

            contactUphillsCount = 0;

            contactDownhillsNormal = Vector3.zero;

            contactDownhillsCount = 0;

            contactWallsCount = 0;

            contactWallsNormal = Vector3.zero;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (groundLayerMask.Contains(collision.gameObject.layer))
            {
                int contactsCount = collision.contacts.Length;

                for (int i = 0; i < contactsCount; ++i)
                {
                    var contact = collision.contacts[i];

#if UNITY_EDITOR

                    if (drawCollisionContacts == true)
                    {
                        Debug.DrawLine(transform.position, contact.point, Color.red, Time.fixedDeltaTime);
                    }

#endif

                    float centerDotContact = Vector3.Dot(contact.point - transform.position, transform.up).Round(1);

                    //Debug.Log(centerDotContact);

                    if (centerDotContact > 0f)
                    {
                        float wallDotDirection = Vector3.Dot(transform.rotation * movementDirection, contact.normal);

                        //Debug.Log(wallDotDirection);

                        if (wallDotDirection < 0f)
                        {
                            ++contactWallsCount;

                            contactWallsNormal += contact.normal;
                        }

                        continue;
                    }

                    float groundAngle = Vector3.Angle(transform.up, contact.normal).Round(2);

                    if (groundAngle > groundedAngleThreshold)
                    {
                        continue;   
                    }

#if UNITY_EDITOR

                    this.groundAngle = groundAngle;

#endif

                    isGrounded = true;

                    float groundDotDirection = Vector3.Dot(transform.rotation * movementDirection, contact.normal).Round(2);

                    Debug.Log(groundDotDirection);

                    if (groundDotDirection < -0.1f)
                    {
                        ++contactUphillsCount;

                        contactUphillsNormal += contact.normal;
                    }

                    else if (groundDotDirection > 0.1f)
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