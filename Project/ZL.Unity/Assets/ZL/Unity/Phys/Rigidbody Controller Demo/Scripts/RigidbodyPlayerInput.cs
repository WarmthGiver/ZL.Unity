using System.Diagnostics.Contracts;
using UnityEngine;

using UnityEngine.InputSystem;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Rigidbody Input")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CapsuleCollider))]

    [RequireComponent(typeof(RigidbodyController))]

    [RequireComponent(typeof(PlayerInput))]

    public class RigidbodyPlayerInput : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private CapsuleCollider capsuleCollider;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RigidbodyController rigidbodyController;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInChildren]

        [Text("[GetComponentInChildren]")]

        private ColliderChecker groundedChecker;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private bool isGrounded = false;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private bool isTouchingWall = false;

        [Space]

        [SerializeField]

        private float moveSpeed = 0f;

        [SerializeField]

        private float sprintSpeed = 0f;

        [SerializeField]

        private float jumpForce = 0f;

        private Vector3 moveDirection;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private bool isUphill = false;

        private void FixedUpdate()
        {
            isGrounded = false;

            isTouchingWall = false;

            isUphill = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (groundedChecker.LayerMask.IsContain(collision.gameObject.layer))
            {
                //isGrounded = groundedChecker.Check();

                int contactsCount = collision.contacts.Length;

                for (int i = 0; i < contactsCount; ++i)
                {
                    var contact = collision.contacts[i];

                    Debug.Log($"angle: {Vector3.Angle(contact.normal, transform.up)}");

                    var bottom = capsuleCollider.bounds.center - transform.up * (capsuleCollider.bounds.extents.y - capsuleCollider.radius);

                    Debug.DrawLine(bottom, contact.point, Color.red, Time.fixedDeltaTime);

                    var contactAngle = Vector3.Angle(contact.normal, transform.up);
                    
                    if (contactAngle > 60f)
                    {
                        isTouchingWall = true;
                    }

                    else
                    {
                        isGrounded = true;

                        float dot = Vector3.Dot(moveDirection, contact.normal);

                        Debug.Log($"dot: {dot}");

                        rigidbodyController.GravityScale = 1f + dot;
                    }
                }

                /*var gravity = rigidbodyController.GravityDirection;

                var slopeDirection = gravity - Vector3.Dot(gravity, averageNormal) * averageNormal;

                slopeDirection.Normalize();

                float dot = Vector3.Dot(moveDirection, slopeDirection);

                if (dot < 0)
                {
                    rigidbodyController.GravityScale = 0f;
                }

                else
                {
                    rigidbodyController.GravityScale = 1f;
                }*/
            }
        }

        protected virtual void OnMove(InputValue inputValue)
        {
            moveDirection = inputValue.Get<Vector3>();

            rigidbodyController.MoveForce = moveDirection * moveSpeed;
        }

        protected virtual void OnJump(InputValue inputValue)
        {
            if (isGrounded == true)
            {
                rigidbodyController.ImpulseForce = inputValue.Get<Vector3>() * jumpForce;
            }
        }
    }
}