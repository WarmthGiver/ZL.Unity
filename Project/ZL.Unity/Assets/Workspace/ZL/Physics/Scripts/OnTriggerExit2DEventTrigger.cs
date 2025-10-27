using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Trigger Exit 2D Event Trigger")]

    public sealed class OnTriggerExit2DEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent<Collider2D> onTriggerExit2DEvent = null;

        private void OnTriggerExit2D(Collider2D other)
        {
            onTriggerExit2DEvent.Invoke(other);
        }
    }
}