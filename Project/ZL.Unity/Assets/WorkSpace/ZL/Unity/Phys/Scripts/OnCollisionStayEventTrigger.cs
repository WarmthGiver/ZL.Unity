using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Phys
{
    [AddComponentMenu("ZL/Phys/On Collision Stay Event Trigger")]

    public sealed class OnCollisionStayEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent<Collision> onCollisionStayEvent = null;

        private void OnCollisionStay(Collision collision)
        {
            onCollisionStayEvent.Invoke(collision);
        }
    }
}