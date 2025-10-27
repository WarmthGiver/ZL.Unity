using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Collision Exit Event Trigger")]

    public sealed class OnCollisionExitEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent<Collision> onCollisionExitEvent = null;

        private void OnCollisionExit(Collision collision)
        {
            onCollisionExitEvent.Invoke(collision);
        }
    }
}