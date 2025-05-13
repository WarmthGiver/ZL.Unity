using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Start Event Trigger")]

    public sealed class OnStartEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent onStartEvent;

        public UnityEvent OnStartEvent
        {
            get => onStartEvent;
        }

        private void Start()
        {
            onStartEvent.Invoke();

            Destroy(this);
        }
    }
}