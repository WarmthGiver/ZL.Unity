using UnityEngine;

using UnityEngine.Events;

using UnityEngine.EventSystems;

namespace ZL.Unity.UI
{
    [DisallowMultipleComponent]

    public abstract class DragEventTrigger : UIBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]

        protected UnityEvent<PointerEventData> onBeginDragEvent = new();

        public UnityEvent<PointerEventData> OnBeginDragEvent => onBeginDragEvent;

        [SerializeField]

        protected UnityEvent<PointerEventData> onDragEvent = new();

        public UnityEvent<PointerEventData> OnDragEvent => onDragEvent;

        [SerializeField]

        protected UnityEvent<PointerEventData> onEndDragEvent = new();

        public UnityEvent<PointerEventData> OnEndDragEvent => onEndDragEvent;

        public virtual void OnBeginDrag(PointerEventData pointEventData)
        {
            onBeginDragEvent.Invoke(pointEventData);
        }

        public virtual void OnDrag(PointerEventData pointEventData)
        {
            onDragEvent.Invoke(pointEventData);
        }

        public virtual void OnEndDrag(PointerEventData pointEventData)
        {
            onEndDragEvent.Invoke(pointEventData);
        }
    }
}