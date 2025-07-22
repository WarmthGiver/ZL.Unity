using UnityEngine;

namespace ZL.Unity.Pooling
{
    [AddComponentMenu("ZL/Pooling/Pooled Game Object")]

    public class PooledGameObject : PooledObject
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

        public override void OnDisappeared()
        {
            base.OnDisappeared();

            if (rigidbody != null)
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}