using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Listener Volume Tweener")]

    [DisallowMultipleComponent]

    public sealed class AudioListenerVolumeTweener :
        
        ComponentValueTweener<FloatTweener, float, float, FloatOptions>, IMonoSingleton<AudioListenerVolumeTweener>
    {
        private void Awake()
        {
            tweener = new()
            {
                Getter = () => AudioListener.volume,

                Setter = value => AudioListener.volume = value,
            };
        }
    }
}