using UnityEngine;

using ZL.CS;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Ping Pong")]

    public sealed class PingPong : MonoBehaviour
    {
        [Space]

        public Vector3 direction = Vector3.zero;

        public float speed = 1f;

        [Space]

        [Range(-2f, 2f)]

        [SerializeField]

        private float theta = 0f;

        [Range(0f, 1f)]

        [SerializeField]

        private float sin = 0.5f;

        private float time = 0f;

        [SerializeField]

        private float delta = 0f;

        private Vector3 moveDirection = Vector3.zero;

        private void Awake()
        {
            time = theta * 0.25f / speed;
        }

        private void Update()
        {
            transform.position -= moveDirection;

            time += Time.deltaTime;

            theta = Mathf.Sin(MathFEx.PI2 * (time + delta) * speed) + sin;

            moveDirection = direction * theta;

            transform.position += moveDirection;
        }
    }
}