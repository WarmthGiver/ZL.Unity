using UnityEngine;

namespace ZL.Unity.Routines
{
    [AddComponentMenu("ZL/Routines/Spin(Routine)")]

    public sealed class SpinRoutine : TransformRoutine
    {
        [Space]

        [SerializeField]

        private Space space = Space.Self;

        protected override void FixedUpdate()
        {
            transform.Rotate(speed * Time.fixedDeltaTime * direction, space);
        }
    }
}