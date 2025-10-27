// Working

#pragma warning disable

using System;

using UnityEngine;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Rigidbody Character Controller")]

    public class RigidbodyCharacterController : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        #pragma warning disable CS0108

        private Rigidbody rigidbody = null;

        public Rigidbody Rigidbody
        {
            get => rigidbody;
        }

        #pragma warning restore CS0108

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private GravityController gravityController = null;

        [Space]

        [UsingCustomProperty]

        [SerializeField]

        private bool keepRotationUpright = true;

        public bool KeepRotationUpright
        {
            get => keepRotationUpright;

            set => keepRotationUpright = value;
        }

        [ToggleIf(nameof(keepRotationUpright), false)]

        [AddIndent]

        [Alias("Use Slerp")]

        [UsingCustomProperty]

        [SerializeField]

        private bool rotateUprightSlerp = true;

        [ToggleIf(nameof(keepRotationUpright), false)]

        [ToggleIf(nameof(rotateUprightSlerp), false)]

        [AddIndent]

        [Alias("Speed")]

        [UsingCustomProperty]

        [Min(0f)]

        [SerializeField]

        private float rotateUprightSpeed = 10f;

        [Space]

        [Line(Margin = 0)]

        [Text("<b>Grounding</b>", FontSize = 16)]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        protected LayerMask groundLayerMask = 0;

        public LayerMask GroundLayerMask
        {
            get => groundLayerMask;

            set => groundLayerMask = value;
        }

        [Min(0f)]

        [SerializeField]

        private float groundSlopeThreshold = 45f;

        public float GroundedSlopeThreshold
        {
            get => groundSlopeThreshold;

            set => groundSlopeThreshold = value;
        }

        #if UNITY_EDITOR

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private float groundSlope = 0f;

        #endif

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        protected bool isGrounded = false;

        public bool IsGrounded
        {
            get => isGrounded;
        }

        private int contactUphillsCount;

        private Vector3 contactUphillsNormal;

        private int contactDownhillsCount;

        private Vector3 contactDownhillsNormal;

        private int contactWallsCount;

        private Vector3 contactWallsNormal;

        [Space]

        [Line(Margin = 0)]

        [Text("<b>Controls</b>", FontSize = 16)]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

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

        [UsingCustomProperty]

        [SerializeField]

        protected Vector3 impulseForce = Vector3.zero;

        public Vector3 ImpulseForce
        {
            get => impulseForce;

            set => impulseForce = value;
        }

        #if UNITY_EDITOR

        [Space]

        [Line(Margin = 0)]

        [Text("<b>Debugging</b>", FontSize = 16)]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private bool drawMovementForceGizmo = true;

        [UsingCustomProperty]

        [SerializeField]

        private bool drawCollisionContactGizmo = true;

        #endif

        protected virtual void FixedUpdate()
        {
            var uprightRotation = Quaternion.FromToRotation(-transform.up, gravityController.GravityDirection) * transform.rotation;

            if (keepRotationUpright == true)
            {
                if (rotateUprightSlerp == true)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, uprightRotation, rotateUprightSpeed * Time.fixedDeltaTime);
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

            #if UNITY_EDITOR

            if (drawMovementForceGizmo == true)
            {
                Debug.DrawLine(transform.position, transform.position + movementSpeed * direction, movementDirection.ToColor());
            }

            #endif

            rigidbody.MovePosition(transform.position + movementSpeed * Time.fixedDeltaTime * direction);

            rigidbody.AddRelativeForce(impulseForce, ForceMode.VelocityChange);

            impulseForce = Vector3.zero;

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

                    float directionDotContactNormal = 0f;

                    if (bottomDotContact > 0f)
                    {
                        directionDotContactNormal = Vector3.Dot(transform.rotation * movementDirection, contact.normal);

                        if (directionDotContactNormal < 0f)
                        {
                            ++contactWallsCount;

                            contactWallsNormal += contact.normal;
                        }

                        continue;
                    }

                    float groundSlope = Vector3.Angle(transform.up, contact.normal);

                    groundSlope = MathF.Round(groundSlope, 2);

                    if (groundSlope > groundSlopeThreshold)
                    {
                        ++contactWallsCount;

                        contactWallsNormal += contact.normal;

                        continue;
                    }

                    #if UNITY_EDITOR

                    this.groundSlope = groundSlope;

                    #endif

                    isGrounded = true;

                    if (directionDotContactNormal == 0f)
                    {
                        directionDotContactNormal = Vector3.Dot(transform.rotation * movementDirection, contact.normal);
                    }

                    if (MathF.Round(directionDotContactNormal, 2) < -0.1f)
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