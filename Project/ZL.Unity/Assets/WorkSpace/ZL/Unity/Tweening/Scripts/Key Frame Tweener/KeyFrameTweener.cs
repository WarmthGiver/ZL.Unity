using DG.Tweening.Plugins.Options;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Tweening
{
    [DisallowMultipleComponent]

    public abstract class KeyFrameTweener<TComponentTweener, TValueTweener, T1, T2, TPlugOptions> : MonoBehaviour

        where TComponentTweener : ComponentValueTweener<TValueTweener, T1, T2, TPlugOptions>

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        protected TComponentTweener componentTweener;

        #if UNITY_EDITOR

        [Space]

        [SerializeField]

        private bool preview = false;

        #endif

        [Space]

        [SerializeField]

        protected LoopList<T2> keyFrames;

        #if UNITY_EDITOR

        private void OnValidate()
        {
            if (preview == true)
            {
                SetKeyFrame(keyFrames.Index);
            }
        }

        #endif

        private void Awake()
        {
            SetKeyFrame(keyFrames.Index);
        }

        public abstract void SetKeyFrame(int index);

        public void TweenKeyFrameNext()
        {
            ++keyFrames.Index;

            TweenKeyFrame();
        }

        public void TweenKeyFramePrev()
        {
            --keyFrames.Index;

            TweenKeyFrame();
        }

        public void TweenKeyFrame(int index)
        {
            keyFrames.Index = index;

            TweenKeyFrame();
        }

        protected virtual void TweenKeyFrame()
        {
            if (keyFrames.TryGetCurrent(out T2 endValue) == true)
            {
                componentTweener.Tween(endValue);
            }
        }
    }
}