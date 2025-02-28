using UnityEngine;

using ZL.Unity.Phys;

namespace ZL.Unity.Game
{
    [RequireComponent(typeof(CharacterController))]

    public class GravitationalCharacterController : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private CharacterController characterController;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInChildren]

        [Essential]

        [Text("[GetComponentInChildren]")]

        private ColliderCheckSphere groundedCheckSphere;

        [Space]

        [SerializeField]

        private float gravity = -9.81f;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private float gravityAcceleration = 0f;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private Vector3 velocity = Vector3.zero;

        [Space]

        [SerializeField]

        private Vector3 lastPosition;

        [Space]

        [SerializeField]

        private Vector3 nextPosition;

        private void Start()
        {
            lastPosition = transform.position;

            nextPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (groundedCheckSphere.Check() == true)
            {
                gravityAcceleration = 0f;
            }

            else
            {
                gravityAcceleration += gravity * Time.fixedDeltaTime;
            }

            velocity.y += gravityAcceleration;

            lastPosition = nextPosition;

            nextPosition = transform.position + velocity * Time.fixedDeltaTime;
        }

        private void Update()
        {
            float interpolation = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;

            characterController.Move(Vector3.Lerp(lastPosition, nextPosition, interpolation) - transform.position);
        }

        public void Move(Vector3 velocity)
        {
            this.velocity = velocity;
        }
    }
}