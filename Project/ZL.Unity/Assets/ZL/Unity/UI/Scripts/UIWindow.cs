using UnityEngine;

using UnityEngine.EventSystems;

using ZL.Unity.Tweeners;

namespace ZL.Unity.UI
{
    [RequireComponent(typeof(CanvasGroupTweener))]

    public abstract class UIWindow : MonoBehaviour, IPointerDownHandler
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponentInParent]

        private UIWindowManager playerCanvas;

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private CanvasGroupTweener canvasGroupTweener;

        public void OnPointerDown(PointerEventData eventData)
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