using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Events
{
    public abstract class OnStopEventTrigger<T> : MonoBehaviour

        where T : Component
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        protected T target;

        public T Target
        {
            get => target;
        }

        [Space]

        [SerializeField]

        private UnityEvent onStopEvent;

        public UnityEvent OnStopEvent
        {
            get => onStopEvent;
        }

        public abstract bool IsStoped { get; }

        private void LateUpdate()
        {
            if (IsStoped == true)
            {
                onStopEvent.Invoke();
            }
        }
    }
}