using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.UI
{
    using ZL.Tweeners;

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupTweener))]

    public abstract class UIWindow : MonoBehaviour, IPointerDownHandler
    {
        [Space]

        [SerializeField, GetComponentInParentOnly, ReadOnly]

        private UIWindowManager playerCanvas;

        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private CanvasGroupTweener canvasGroupTweener;

        public void OnPointerDown(PointerEventData pointEventData)
        {
            SetAsLastSibling();
        }

        private void SetAsLastSibling()
        {
            transform.SetAsLastSibling();
        }

        public virtual void Open()
        {
            SetAsLastSibling();

            canvasGroupTweener.TweenFaded(false);
        }

        public virtual void Close()
        {
            canvasGroupTweener.TweenFaded(true);
        }
    }
}