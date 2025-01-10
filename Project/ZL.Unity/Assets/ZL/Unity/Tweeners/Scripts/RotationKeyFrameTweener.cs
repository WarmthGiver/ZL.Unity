using DG.Tweening;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public sealed class RotationKeyFrameTweener : KeyFrameTweener
    {
        public override int KeyFrameIndex
        {
            set
            {
                base.KeyFrameIndex = value;

                transform.localEulerAngles = keyFrames[keyFrameIndex];
            }
        }

        private void Reset()
        {
            keyFrames = new Vector3[]
            {
                transform.localEulerAngles,
            };
        }

        public override void TweenSetKeyFrameIndex(int value)
        {
            base.TweenSetKeyFrameIndex(value);

            transformTweener.TweenLocalRotation(keyFrames[value], duration, RotateMode.FastBeyond360);
        }
    }
}