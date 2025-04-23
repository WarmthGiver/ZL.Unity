using UnityEngine;

namespace ZL.Routines
{
    public abstract class TransformRoutine : MonoBehaviour
    {
        [Space]

        [SerializeField]

        protected Vector3 direction = Vector3.zero;

        [SerializeField]

        protected float speed = 0f;

        private void Awake()
        {
            direction = direction.normalized;
        }

        protected abstract void Update();
    }
}