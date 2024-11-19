using DG.Tweening;

using UnityEngine;

namespace ZL.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Tweener")]

    public sealed class TransformTweener : MonoBehaviour
    {
        private Tweener tweenAnchorPos;

        public Tweener TweenPosition(in Vector3 position, float duration)
        {
            tweenAnchorPos.Kill();

            return tweenAnchorPos = transform.DOMove(position, duration);
        }

        private Tweener tweenRotation;

        public Tweener TweenRotation(in Vector3 rotation, float duration, RotateMode rotateMode = RotateMode.Fast)
        {
            tweenRotation.Kill();

            return tweenRotation = transform.DORotate(rotation, duration, rotateMode);
        }

        private Tweener tweenLocalRotation;

        public Tweener TweenLocalRotation(in Vector3 rotation, float duration, RotateMode rotateMode = RotateMode.Fast)
        {
            tweenLocalRotation.Kill();

            return tweenLocalRotation = transform.DOLocalRotate(rotation, duration, rotateMode);
        }

        private Tweener tweenScale;

        public Tweener TweenScale(in Vector3 scale, float duration)
        {
            tweenScale.Kill();

            return tweenScale = transform.DOScale(scale, duration);
        }
    }
}