using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweening
{
    [AddComponentMenu("ZL/Tweening/Light Intensity Tweener")]

    public sealed class LightIntensityTweener : LightValueTweener<FloatTweener, float, float, FloatOptions>
    {
        public override float Value
        {
            get => light.intensity;
            
            set => light.intensity = value;
        }
    }
}