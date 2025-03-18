using UnityEngine;

namespace ZL.Unity.UI
{
    [RequireComponent(typeof(CanvasGroupAnimation))]

    public abstract class WindowUGUI : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private CanvasGroupAnimation canvasGroupAnimation;

        public virtual void Open()
        {
            transform.SetAsLastSibling();

            if (canvasGroupAnimation != null)
            {
                canvasGroupAnimation.SetFaded(false);
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
                canvasGroupAnimation.SetFaded(true);
            }

            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}