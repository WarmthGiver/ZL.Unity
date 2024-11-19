using UnityEngine;

namespace ZL.Tweeners
{
    public sealed class ScaleKeyFrameTweener : KeyFrameTweener
    {
        public override int KeyFrameIndex
        {
            set
            {
                base.KeyFrameIndex = value;

                transform.localScale = keyFrames[keyFrameIndex];
            }
        }

        private void Reset()
        {
            keyFrames = new Vector3[]
            {
                transform.localScale,
            };
        }

        public override void TweenSetKeyFrameIndex(int value)
        {
            base.TweenSetKeyFrameIndex(value);

            transformTweener.TweenScale(keyFrames[value], duration);
        }
    }
}