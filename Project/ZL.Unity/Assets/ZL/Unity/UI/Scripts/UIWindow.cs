using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.Unity.UI
{
    [RequireComponent(typeof(CanvasGroupFader))]

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

        private CanvasGroupFader canvasGroupFader;

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }

        public virtual void Open()
        {
            transform.SetAsLastSibling();

            canvasGroupFader.TweenFaded(false);
        }

        public virtual void Close()
        {
            canvasGroupFader.TweenFaded(true);
        }
    }
}