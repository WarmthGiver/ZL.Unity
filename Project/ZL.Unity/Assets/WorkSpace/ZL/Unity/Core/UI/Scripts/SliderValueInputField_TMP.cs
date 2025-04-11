using TMPro;

using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Slider Value Input Field (TMP)")]

    [DisallowMultipleComponent]

    [ExecuteInEditMode]

    public sealed class SliderValueInputField_TMP : SliderValueDisplayer<TMP_InputField>
    {
#if UNITY_EDITOR

        private string inputText = null;

        protected override void Awake()
        {
            if (slider != null)
            {
                sliderValue = slider.value;
            }

            if (valueTextController != null)
            {
                inputText = valueTextController.Text;
            }
        }

        protected override void Update()
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

                else if (inputText != valueTextController.Text)
                {
                    TrySetValue(valueTextController.Text);
                }

                inputText = valueTextController.Text;

                sliderValue = slider.value;
            }
        }

#endif

        public void TrySetValue(string text)
        {
            if (float.TryParse(text, out float value) == true)
            {
                slider.value = value;
            }
        }
    }
}