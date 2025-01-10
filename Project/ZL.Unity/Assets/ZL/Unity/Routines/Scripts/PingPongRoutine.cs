using UnityEngine;

namespace ZL.Unity.Routines
{
    [AddComponentMenu("ZL/Routines/Ping Pong(Routine)")]

    public sealed class PingPongRoutine : TransformRoutine
    {
        [Space]

        [SerializeField, Range(-1f, 1f)]

        private float theta = 0f;

        public float Theta
        {
            get => theta + delay;

            set
            {
                theta = Mathf.Clamp(value, -1f, 1f);

                time = theta * 0.25f / speed;
            }
        }

        [SerializeField, Range(0f, 1f)]

        private float delay = 0f;

        private float time;

        private Vector3 moveDirection = Vector3.zero;

        private void Awake()
        {
            Theta = theta;
        }

        private void OnValidate()
        {
            Theta = theta;
        }

        protected override void FixedUpdate()
        {
            transform.position -= moveDirection;

            time += Time.fixedDeltaTime;

            theta = Mathf.Sin(MathEx.PI2 * time * speed);

            moveDirection = direction * Theta;

            transform.position += moveDirection;
        }
    }
}