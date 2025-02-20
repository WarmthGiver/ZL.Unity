using UnityEngine;

namespace ZL.CS.Unity.Routines
{
    [AddComponentMenu("ZL/Routines/Spin (Routine)")]

    public sealed class SpinRoutine : TransformRoutine
    {
        [Space]

        [SerializeField]

        private Space space = Space.Self;

        protected override void Update()
        {
            transform.Rotate(speed * Time.deltaTime * direction, space);
        }
    }
}