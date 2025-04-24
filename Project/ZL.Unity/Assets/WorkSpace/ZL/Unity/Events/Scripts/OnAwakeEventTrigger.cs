using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Events
{
    [AddComponentMenu("ZL/Events/On Awake Event Trigger")]

    [DisallowMultipleComponent]

    public sealed class OnAwakeEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent onAwakeEvent;

        private void Awake()
        {
            onAwakeEvent.Invoke();

            Destroy(this);
        }
    }
}