using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/Draggable Rect")]

    public sealed class DraggableRect : DragEventTrigger
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        [SerializeField, GetComponentInParentOnly, ReadOnly]

        private Canvas canvas;

        public override void OnDrag(PointerEventData pointEventData)
        {
            rectTransform.anchoredPosition += pointEventData.delta / canvas.scaleFactor;

            base.OnDrag(pointEventData);
        }
    }
}