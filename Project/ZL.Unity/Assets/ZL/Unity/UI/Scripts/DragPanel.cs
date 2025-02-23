using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.Events;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Drag Panel")]

    [DisallowMultipleComponent]

    public sealed class DragPanel : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Space]

        [SerializeField]

        private RectTransform container = null;

        [Space]

        [SerializeField]

        private float dragSensitivity = 0.01f;

        [SerializeField]

        private float maxMagnitude = 10f;

        [Space]

        [SerializeField]

        private bool debug;

        [Space]

        [SerializeField]
        
        [UsingCustomProperty]

        [ReadOnly(true)]

        private Vector2 pointerDownPosition;

        [SerializeField]
        
        [UsingCustomProperty]

        [ReadOnly(true)]

        private Vector2 dragDirection;

        [Space]

        [SerializeField]

        private UnityEvent<Vector2> eventOnDrag;

        public Vector2 DragDirection => dragDirection;

        public UnityEvent<Vector2> EventOnDrag => eventOnDrag;

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(container, eventData.position, eventData.pressEventCamera, out var pointerDragPosition);

            dragDirection = Vector2.ClampMagnitude((pointerDragPosition - pointerDownPosition) * dragSensitivity, maxMagnitude);

            eventOnDrag.Invoke(dragDirection);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(container, eventData.position, eventData.pressEventCamera, out pointerDownPosition);

            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            dragDirection = Vector2.zero;

            eventOnDrag.Invoke(Vector2.zero);
        }
    }
}