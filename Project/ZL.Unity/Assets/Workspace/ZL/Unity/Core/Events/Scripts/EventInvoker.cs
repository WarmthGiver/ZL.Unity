using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Events
{
    [AddComponentMenu("ZL/Events/Event Invoker")]

	[DisallowMultipleComponent]

	public sealed class EventInvoker : MonoBehaviour
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

        private UnityEvent eventOnTime;

        public UnityEvent EventOnTime => eventOnTime;

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
            eventOnTime.Invoke();
        }
	}
}