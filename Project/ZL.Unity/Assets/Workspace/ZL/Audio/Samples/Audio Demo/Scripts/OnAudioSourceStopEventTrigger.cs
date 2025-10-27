using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Audio Source Stop Event Trigger")]

    public sealed class OnAudioSourceStopEventTrigger : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private AudioSource audioSource = null;

        [Space]

        [SerializeField]

        private UnityEvent onAudioSourceStopEvent = null;

        public UnityEvent OnAudioSourceStopEvent
        {
            get => onAudioSourceStopEvent;
        }

        private void LateUpdate()
        {
            if (audioSource.isPlaying == false)
            {
                OnAudioSourceStopEvent.Invoke();
            }
        }
    }
}