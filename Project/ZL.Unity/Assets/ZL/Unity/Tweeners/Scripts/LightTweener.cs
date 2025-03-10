using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Light Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Light))]

    public sealed class LightTweener : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [ReadOnly(true)]

        [GetComponent]

        [UsingCustomProperty]

        private Light _light;

        public FloatTweener IntensityTweener { get; private set; }

        private void Awake()
        {
            IntensityTweener = new()
            {
                Getter = () => _light.intensity,
                
                Setter = value => _light.intensity = value
            };
        }
    }
}