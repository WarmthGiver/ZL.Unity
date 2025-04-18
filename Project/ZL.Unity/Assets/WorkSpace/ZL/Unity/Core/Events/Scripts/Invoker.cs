using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Events
{
    [AddComponentMenu("ZL/Events/Invoker")]

	[DisallowMultipleComponent]

	public sealed class Invoker : MonoBehaviour
	{
        [Space]

		[SerializeField]

		private float time = 0f;

        public float Time
        {
            get => time;

            set => time = value;
        }

        [Space]

        [SerializeField]

        private UnityEvent onTimeEvent;

        public UnityEvent OnTimeEvent
        {
            get => onTimeEvent;
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(OnTime));
        }

        public void Invoke()
        {
            Invoke(time);
        }

        public void Invoke(float time)
        {
            Invoke(nameof(OnTime), time);
        }

        private void OnTime()
        {
            onTimeEvent.Invoke();
        }
	}
}