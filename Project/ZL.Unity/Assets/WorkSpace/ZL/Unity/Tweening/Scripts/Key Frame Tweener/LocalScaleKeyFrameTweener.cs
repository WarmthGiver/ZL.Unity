using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Local Scale Key Frame Tweener")]

    public sealed class LocalScaleKeyFrameTweener : KeyFrameTweener<Vector3Tweener, Vector3, Vector3, VectorOptions, LocalScaleTweener>
    {
        public override void SetKeyFrame(int index)
        {
            keyFrames.Index = index;

            if (keyFrames.TryGetCurrent(out var localScale) == true)
            {
                transform.localScale = localScale;
            }
        }
    }
}