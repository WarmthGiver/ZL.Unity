using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Collision Stay Event Trigger")]

    public sealed class OnCollisionStayEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private LayerMask layerMask = ~0;

        [Space]

        [SerializeField]

        private UnityEvent<Collision> onCollisionStayEvent = null;

        private void OnCollisionStay(Collision collision)
        {
            if (layerMask.Contains(collision.gameObject.layer) == false)
            {
                return;
            }

            onCollisionStayEvent.Invoke(collision);
        }
    }
}