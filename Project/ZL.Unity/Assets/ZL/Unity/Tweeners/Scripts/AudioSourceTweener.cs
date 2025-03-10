using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Source Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioSource))]

    public sealed class AudioSourceTweener : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private AudioSource audioSource;

        public FloatTweener VolumeTweener { get; private set; }

        private void Awake()
        {
            VolumeTweener = new()
            {
                Getter = () => audioSource.volume,

                Setter = value => audioSource.volume = value
            };
        }
    }
}