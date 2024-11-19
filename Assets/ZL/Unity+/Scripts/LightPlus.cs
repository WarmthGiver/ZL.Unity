using DG.Tweening;

using UnityEngine;

namespace ZL
{
    [AddComponentMenu("ZL/Light+")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Light))]

    public sealed class LightPlus : MonoBehaviour
    {
#pragma warning disable CS0109

        [SerializeField, GetComponent, ReadOnly]

        private new Light light;

#pragma warning restore CS0109

        public Light Light => light;

        private LightInfo info;

        public Color Color
        {
            get => light.color;

            set
            {
                light.color = value;

                info.color = value;
            }
        }

        public float Intensity
        {
            get => light.intensity;

            set
            {
                light.intensity = value;

                info.intensity = value;
            }
        }

        public Quaternion Rotation
        {
            get => transform.rotation;

            set
            {
                transform.rotation = value;

                info.rotation = value;
            }
        }

        public void Initialize(LightInfo info)
        {
            this.info = info;

            light.color = info.color;

            light.intensity = info.intensity;

            transform.rotation = info.rotation;
        }

        public Tweener DOFade(float targetIntensity, float duration)
        {
            return light.DOIntensity(targetIntensity, duration);
        }
    }
}