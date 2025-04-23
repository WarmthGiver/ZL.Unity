using UnityEngine;

namespace ZL.Routines
{
    [AddComponentMenu("ZL/Routines/Spinner")]

    public sealed class Spinner : TransformRoutine
    {
        [Space]

        [SerializeField]

        private Space relativeTo = Space.Self;

        protected override void Update()
        {
            transform.Rotate(speed * Time.deltaTime * direction, relativeTo);
        }
    }
}