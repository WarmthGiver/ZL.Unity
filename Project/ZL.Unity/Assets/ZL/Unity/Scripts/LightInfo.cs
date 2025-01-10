using UnityEngine;

namespace ZL.Unity
{
    public sealed class LightInfo
    {
        public Color color = Color.white;

        public float intensity = 1f;

        public Quaternion rotation = Quaternion.identity;

        public LightInfo()
        {

        }

        public LightInfo(in Color color, float intensity, in Quaternion rotation)
        {
            this.color = color;

            this.intensity = intensity;

            this.rotation = rotation;
        }
    }
}