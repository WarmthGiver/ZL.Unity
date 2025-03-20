using UnityEngine;

namespace ZL.Unity.Routines
{
    [AddComponentMenu("ZL/Routines/Ping Pong (Routine)")]

    public sealed class PingPongRoutine : TransformRoutine
    {
        [Space]

        [SerializeField]
        
        [Range(-1f, 1f)]

        private float theta = 0f;

        [SerializeField]
        
        [Range(0f, 1f)]

        private float delay = 0f;

        private float time = 0f;

        [SerializeField]

        private float delta = 0f;

        private Vector3 moveDirection = Vector3.zero;

        private void Awake()
        {
            time = theta * 0.25f / speed;
        }

        protected override void Update()
        {
            transform.position -= moveDirection;

            time += Time.deltaTime;

            theta = Mathf.Sin(MathEx.PI2 * (time + delta) * speed) + delay;

            moveDirection = direction * theta;

            transform.position += moveDirection;
        }
    }
}