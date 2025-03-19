using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Draggable Rect")]

    [DisallowMultipleComponent]

    public sealed class DraggableRect : UIBehaviour, IDragHandler
    {
        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [Toggle(true)]

        private RectTransform rectTransform;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInParent]

        private Canvas canvas;

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}