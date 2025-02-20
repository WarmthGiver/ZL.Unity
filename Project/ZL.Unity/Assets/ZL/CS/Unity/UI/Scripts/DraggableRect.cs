using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.CS.Unity.UI
{
    [AddComponentMenu("ZL/UI/Draggable Rect")]

    public sealed class DraggableRect : DragEventTrigger
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private RectTransform rectTransform;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInParent]

        private Canvas canvas;

        public override void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

            base.OnDrag(eventData);
        }
    }
}