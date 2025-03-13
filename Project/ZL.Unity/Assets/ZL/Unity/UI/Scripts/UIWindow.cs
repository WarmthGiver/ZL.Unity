using UnityEngine;

using UnityEngine.EventSystems;

namespace ZL.Unity.UI
{
    [RequireComponent(typeof(CanvasGroupAnimation))]

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

        private CanvasGroupAnimation canvasGroupAnimation;

        [Space]

        [SerializeField]

        private float fadeDuration = 0.5f;

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.SetAsLastSibling();
        }

        public virtual void Open()
        {
            transform.SetAsLastSibling();

            if (canvasGroupAnimation != null)
            {
                canvasGroupAnimation.SetFaded(false, fadeDuration);
            }

            else
            {
                gameObject.SetActive(true);
            }
        }

        public virtual void Close()
        {
            if (canvasGroupAnimation != null)
            {
                canvasGroupAnimation.SetFaded(true, fadeDuration);
            }

            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}