using UnityEngine;

namespace ZL.Unity
{
    public abstract class ColliderChecker : MonoBehaviour
    {
        [GetComponent]

        [Toggle(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Transform _transform;

        public new Transform transform
        {
            get => _transform;
        }

        [Space]

        [SerializeField]

        protected LayerMask layer = 0;

        public LayerMask Layer
        {
            set => layer = value;
        }

        [SerializeField]

        protected QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal;

        public abstract bool Check();

        public abstract int Overlap(Collider[] results);
    }
}