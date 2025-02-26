using UnityEngine;

using UnityEngine.InputSystem;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/Rigidbody Input")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(RigidbodyController))]

    [RequireComponent(typeof(PlayerInput))]

    public class RigidbodyInput : MonoBehaviour
    {
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

        [Essential]

        [Text("[GetComponentInChildren]")]

        private CheckSphere groundedCheckSphere;

        [Space]

        [SerializeField]

        private float moveSpeed = 0f;

        [Space]

        [SerializeField]

        private float jumpForce = 0f;

        private void OnMove(InputValue inputValue)
        {
            rigidbodyController.Move(inputValue.Get<Vector3>().normalized * moveSpeed);
        }

        private void OnJump(InputValue inputValue)
        {
            rigidbodyController.Impulse(inputValue.Get<Vector3>() * jumpForce);
        }
    }
}