using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.Events;

namespace ZL.UI
{
    [DisallowMultipleComponent]

    public sealed class DragPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]

        private RectTransform container = null;

        [SerializeField]

        private float dragSensitivity = 0.01f;

        [SerializeField]

        private float maxMagnitude = 10f;

        [SerializeField, ReadOnly]

        private Vector2 pointerDownPosition;

        [SerializeField, ReadOnly]

        private Vector2 dragDirection;

        [SerializeField]

        private UnityEvent<Vector2> eventOnDrag;

        public Vector2 DragDirection => dragDirection;

        public UnityEvent<Vector2> EventOnDrag => eventOnDrag;

        public void OnDrag(PointerEventData pointerEventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(container, pointerEventData.position, pointerEventData.pressEventCamera, out Vector2 pointerDragPosition);

            dragDirection = Vector2.ClampMagnitude((pointerDragPosition - pointerDownPosition) * dragSensitivity, maxMagnitude);

            eventOnDrag.Invoke(dragDirection);
        }

        public void OnPointerDown(PointerEventData pointerEventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(container, pointerEventData.position, pointerEventData.pressEventCamera, out pointerDownPosition);

            OnDrag(pointerEventData);
        }

        public void OnPointerUp(PointerEventData pointerEventData)
        {
            dragDirection = Vector2.zero;

            eventOnDrag.Invoke(Vector2.zero);
        }
    }
}