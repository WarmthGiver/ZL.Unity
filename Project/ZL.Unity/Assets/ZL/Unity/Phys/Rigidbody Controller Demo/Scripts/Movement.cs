using UnityEngine;

using UnityEngine.InputSystem;

namespace ZL.Unity.Game
{
    [RequireComponent(typeof(PlayerInput))]

    public abstract class Movement : MonoBehaviour
    {
        [Space]

        [SerializeField]

        protected float speed = 10f;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        protected Vector3 velocity;

        public Vector3 Velocity => velocity;

        private void OnMove(InputValue inputValue)
        {
            velocity = inputValue.Get<Vector3>().normalized * speed;
        }

        private void OnJump(InputValue inputValue)
        {
            Debug.Log("Jump");
        }
    }
}