using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [RequireComponent(typeof(TransformTweener))]

    public abstract class KeyFrameTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        protected TransformTweener transformTweener;

        [Space]

        [SerializeField]

        protected float duration = 0.5f;

        [Space]

        [SerializeField]

        protected int keyFrameIndex = 0;

        public virtual int KeyFrameIndex
        {
            get => keyFrameIndex;

            set => keyFrameIndex = value.Repeat(keyFrameIndex_Max);
        }

        private int keyFrameIndex_Max;

        [Space]

        [SerializeField]

        protected Vector3[] keyFrames;

        private void Awake()
        {
            keyFrameIndex_Max = keyFrames.Length;

            KeyFrameIndex = keyFrameIndex;
        }

        private void OnValidate()
        {
            Awake();
        }

        public virtual void TweenSetKeyFrameIndex(int value)
        {
            keyFrameIndex = value.Repeat(keyFrameIndex_Max);
        }

        public void TweenAddKeyFrameIndex(int value)
        {
            TweenSetKeyFrameIndex(keyFrameIndex + value);
        }

        public void TweenAddKeyFrameIndex()
        {
            TweenSetKeyFrameIndex(++keyFrameIndex);
        }

        public void TweenSubKeyFrameIndex(int value)
        {
            TweenSetKeyFrameIndex(keyFrameIndex - value);
        }

        public void TweenSubKeyFrameIndex()
        {
            TweenSetKeyFrameIndex(--keyFrameIndex);
        }
    }
}