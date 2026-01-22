using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Tweening/Material Float Tweener")]

    public sealed class MaterialFloatTweener : MaterialPropertyTweener<FloatTweener, float, float, FloatOptions>
    {
        public override float Value
        {
            get => material.GetFloat(propertyName);

            set => material.SetFloat(propertyName, value);
        }
    }
}