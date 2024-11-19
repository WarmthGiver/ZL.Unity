using DG.Tweening;

using UnityEngine;

namespace ZL.Tweeners
{
    [RequireComponent(typeof(RectTransform))]

    public sealed class RectTransformTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        private Tweener tweenAnchorPos;

        public Tweener TweenAnchorPos(in Vector2 position, float duration)
        {
            tweenAnchorPos.Kill();

            return tweenAnchorPos = rectTransform.DOAnchorPos(position, duration);
        }
    }
}