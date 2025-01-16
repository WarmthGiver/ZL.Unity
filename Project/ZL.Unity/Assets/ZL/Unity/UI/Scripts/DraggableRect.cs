using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Draggable Rect")]

    public sealed class DraggableRect : DragEventTrigger
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        [SerializeField, GetComponentInParent, ReadOnly]

        private Canvas canvas;

        public override void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            base.OnDrag(eventData);
        }
    }
}