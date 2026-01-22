using DG.Tweening.Plugins.Options;

using UnityEngine;

using UnityEngine.Rendering;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Post Processing/Volume Weight Tweener")]

    public sealed class VolumeWeightTweener : ObjectValueTweener<FloatTweener, float, float, FloatOptions>
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Volume volume = null;

        public override float Value
        {
            get => volume.weight;

            set => volume.weight = value;
        }
    }
}