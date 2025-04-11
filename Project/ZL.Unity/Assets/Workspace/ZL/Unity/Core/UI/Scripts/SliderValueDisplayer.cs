using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [DisallowMultipleComponent]

    public abstract class SliderValueDisplayer<TTextUGUI> : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        protected Slider slider;

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        protected TextController<TTextUGUI> valueTextController;

#if UNITY_EDITOR

        protected float sliderValue = 0f;

        protected virtual void Awake()
        {
            if (slider != null)
            {
                sliderValue = slider.value;
            }
        }

        protected virtual void Update()
        {
            if (Application.isPlaying == true)
            {
                return;
            }

            if (valueTextController != null && slider != null)
            {
                if (sliderValue != slider.value)
                {
                    valueTextController.SetText(slider.value);
                }

                sliderValue = slider.value;
            }
        }

#endif
    }
}