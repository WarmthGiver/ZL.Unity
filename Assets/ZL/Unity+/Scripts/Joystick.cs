using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.Events;

namespace ZL.UI
{
    [DisallowMultipleComponent]

    public sealed class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]

        private RectTransform container = null;

        [SerializeField]

        private RectTransform handle = null;

        [SerializeField, ReadOnly]

        private Vector2 dragDirection = Vector2.zero;

        [SerializeField]

        private float dragRange = 75f;

        [SerializeField]

        private UnityEvent<Vector2> eventOnDrag = null;

        public Vector2 DragDirection => dragDirection;

        private void Start()
        {
            if (handle != null)
            {
                handle.anchoredPosition = Vector2.zero;
            }
        }

        public void OnDrag(PointerEventData pointerEventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(container, pointerEventData.position, pointerEventData.pressEventCamera, out Vector2 pointerPosition);

            if (handle != null)
            {
                handle.anchoredPosition = pointerPosition.magnitude < dragRange ? pointerPosition : pointerPosition.normalized * dragRange;
            }

            dragDirection = new(pointerPosition.x / container.sizeDelta.x, pointerPosition.y / container.sizeDelta.y);

            eventOnDrag.Invoke(dragDirection);
        }

        public void OnPointerDown(PointerEventData pointerEventData)
        {
            OnDrag(pointerEventData);
        }

        public void OnPointerUp(PointerEventData pointerEventData)
        {
            dragDirection = Vector2.zero;

            eventOnDrag.Invoke(Vector2.zero);

            if (handle != null)
            {
                handle.anchoredPosition = Vector2.zero;
            }
        }
    }
}