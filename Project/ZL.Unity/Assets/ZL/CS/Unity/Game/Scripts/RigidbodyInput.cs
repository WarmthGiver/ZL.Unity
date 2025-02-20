using UnityEngine;

using UnityEngine.InputSystem;

namespace ZL.CS.Unity
{
    [DisallowMultipleComponent]

    [RequireComponent(typeof(Rigidbody))]

    [RequireComponent(typeof(PlayerInput))]

    public sealed class RigidbodyInput : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private new Rigidbody rigidbody;

        [Space]

        [SerializeField]

        private LayerMask groundable;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        private Vector3 velocity;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, transform.position + -transform.up);
        }

        private void Update()
        {
            Debug.DrawRay(transform.position, -transform.up);
        }

        

        public void Move(Vector3 velocity)
        {
            
        }

        private float CheckSlope()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up * -1f, out hit, 1.1f, groundable))
            {
                float angle = Vector3.Angle(hit.normal, Vector3.up);
                return angle;
            }


            return 0f; // 바닥이 없으면 경사 0
        }
    }
}