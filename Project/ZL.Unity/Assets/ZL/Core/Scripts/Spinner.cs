using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Spinner")]

    public sealed class Spinner : MonoBehaviour
    {
        [Space]

        public Vector3 direction = Vector3.zero;

        public float speed = 1f;

        [Space]

        [SerializeField]

        private Space relativeTo = Space.Self;

        private void Update()
        {
            transform.Rotate(speed * Time.deltaTime * direction, relativeTo);
        }
    }
}