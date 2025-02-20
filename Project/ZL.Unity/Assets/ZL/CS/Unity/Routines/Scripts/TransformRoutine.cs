using UnityEngine;

namespace ZL.CS.Unity.Routines
{
    public abstract class TransformRoutine : MonoBehaviour
    {
        [Space]

        [SerializeField]

        protected Vector3 direction = new(0f, 0f, 0f);

        [SerializeField]

        protected float speed = 0f;

        protected abstract void Update();
    }
}