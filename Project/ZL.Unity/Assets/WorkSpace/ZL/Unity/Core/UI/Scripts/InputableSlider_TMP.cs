using TMPro;

using UnityEngine;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/Inputable Slider (TMP)")]

    [ExecuteInEditMode]

    public sealed class InputableSlider_TMP : SliderValueDisplayer<TMP_InputField>
    {
        #if UNITY_EDITOR

        private string inputText = null;

        protected override void Awake()
        {
            if (slider != null)
            {
                sliderValue = slider.value;
            }

            if (textController != null)
            {
                inputText = textController.Text;
            }
        }

        protected override void Update()
        {
            if (Application.isPlaying == true)
            {
                return;   
            }

            if (textController != null && slider != null)
            {
                if (sliderValue != slider.value)
                {
                    textController.SetText(slider.value);
                }

                else if (inputText != textController.Text)
                {
                    TrySetValue(textController.Text);
                }

                inputText = textController.Text;

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