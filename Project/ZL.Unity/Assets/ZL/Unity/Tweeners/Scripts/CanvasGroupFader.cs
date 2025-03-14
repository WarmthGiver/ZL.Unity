using DG.Tweening;

using UnityEngine;

using ZL.Unity.Tweeners;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Canvas Group Fader")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupAlphaTweener))]

    public class CanvasGroupFader : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]
        
        [GetComponent]

        private CanvasGroup canvasGroup;

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        [Alias("Alpha Tweener")]

        private CanvasGroupAlphaTweener canvasGroupAlphaTweener;

        [Space]

        [SerializeField]

        private bool isFaded = false;

        public bool IsFaded
        {
            get => isFaded;

            set
            {
                isFaded = value;

                if (isFaded == true)
                {
                    canvasGroup.alpha = 0f;

                    gameObject.SetActive(false);
                }

                else
                {
                    gameObject.SetActive(true);

                    canvasGroup.alpha = 1f;
                }
            }
        }

        private void Awake()
        {
            IsFaded = isFaded;
        }

        public void SetFaded(bool value, float duration)
        {
            isFaded = value;

            if (isFaded == true)
            {
                canvasGroupAlphaTweener.Tween(0f, duration).
                    
                    OnComplete(SetActiveFalse);
            }

            else
            {
                gameObject.SetActive(true);

                canvasGroupAlphaTweener.Tween(1f, duration);
            }
        }

        private void SetActiveFalse()
        {
            gameObject.SetActive(false);
        }
    }
}