using UnityEngine;

namespace ZL.Unity.Routines
{
    public abstract class TransformRoutine : MonoBehaviour
    {
        [Space]

        public Vector3 direction = new(0f, 0f, 0f);

        public float speed = 0f;

        protected abstract void FixedUpdate();
    }
}