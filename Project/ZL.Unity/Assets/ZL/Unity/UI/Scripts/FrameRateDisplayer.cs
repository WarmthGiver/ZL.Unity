using TMPro;

using UnityEngine;

namespace ZL.Unity.UI
{
    public sealed class FrameRateDisplayer : MonoBehaviour
    {
        public static FrameRateDisplayer Instance { get; private set; }

        [Space]

        [SerializeField, Essential]

        private TMP_Text frameRateText = null;

        [SerializeField]

        private BoolPref displayFrameRate = new("Display Frame Rate", false);

        public static bool DisplayFrameRate
        {
            set
            {
                Instance.displayFrameRate.Value = value;

                Instance.gameObject.SetActive(value);
            }
        }

        [SerializeField]

        private string format = "{0:0.0} ms ({1:0} fps)";

        private float time = 0f;

        private float ms;

        private float fps;

        private void Awake()
        {
            Instance = this;

            displayFrameRate.TryLoadValue();

            DisplayFrameRate = displayFrameRate.Value;
        }

        private void FixedUpdate()
        {
            time += (Time.unscaledDeltaTime - time) * 0.1f;

            ms = 1000f * time;

            fps = 1f / time;

            frameRateText.text = string.Format(format, ms, fps);
        }
    }
}