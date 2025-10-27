using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Event Invoker")]

    public sealed class EventInvoker : MonoBehaviour
    {
        [Space]

        [Min(0f)]

        [SerializeField]

        private float time = 0f;

        public float Time
        {
            get => time;

            set => time = value;
        }

        [Space]

        [SerializeField]

        private UnityEvent onTimeElapsedEvent = new();

        public UnityEvent OnTimeElapsedEvent
        {
            get => onTimeElapsedEvent;
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(OnTimeElapsed));
        }

        public void Invoke()
        {
            Invoke(time);
        }

        public void Invoke(float time)
        {
            Invoke(nameof(OnTimeElapsed), time);
        }

        private void OnTimeElapsed()
        {
            onTimeElapsedEvent.Invoke();
        }
	}
}