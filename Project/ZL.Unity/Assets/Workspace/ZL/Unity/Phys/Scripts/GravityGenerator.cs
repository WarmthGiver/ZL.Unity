using UnityEngine;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Unity/Phys/Gravity Generator")]

    [DisallowMultipleComponent]

    public sealed class GravityGenerator : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private float gravityStrength = 9.81f;

        public float GravityStrength
        {
            get => gravityStrength;

            set => gravityStrength = value;
        }

        public Vector3 GetGravityDirection(Vector3 position)
        {
            return transform.position - position;
        }
    }
}