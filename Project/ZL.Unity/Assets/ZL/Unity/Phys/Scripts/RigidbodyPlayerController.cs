using UnityEngine;

using UnityEngine.InputSystem;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Rigidbody Player Controller")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(PlayerInput))]

    public class RigidbodyPlayerController : RigidbodyCharacterController
    {
        protected virtual void OnMove(InputValue inputValue)
        {
            movementDirection = inputValue.Get<Vector3>();
        }

        protected virtual void OnJump(InputValue inputValue)
        {
            if (isGrounded == true)
            {
                jumpDirection = inputValue.Get<Vector3>();
            }
        }
    }
}