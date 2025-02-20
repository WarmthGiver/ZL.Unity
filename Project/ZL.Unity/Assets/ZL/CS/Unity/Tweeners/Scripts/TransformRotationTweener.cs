using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.CS.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Rotation Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformRotationTweener : ComponentValueTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        private void Awake()
        {
            tweener = new(() => transform.rotation, value => transform.rotation = value);
        }
    }
}