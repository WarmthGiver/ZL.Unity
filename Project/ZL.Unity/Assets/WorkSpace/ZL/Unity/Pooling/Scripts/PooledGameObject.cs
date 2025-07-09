using UnityEngine;
using UnityEngine.Pool;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("")]

    public sealed class PooledGameObject : PooledObject
    {
        [Space]

        [GetComponent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        #pragma warning disable CS0108

        private Rigidbody rigidbody = null;

        #pragma warning restore CS0108

        public Rigidbody Rigidbody
        {
            get => rigidbody;
        }


    }
}