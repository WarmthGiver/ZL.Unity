using TMPro;

using UnityEngine;

using ZL.Unity.IO;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Frame Rate Displayer")]

    [DisallowMultipleComponent]

    public sealed class FrameRateDisplayer : MonoBehaviour, ISingleton<FrameRateDisplayer>
    {
        [Space]

        [SerializeField]

        private TextMeshProUGUI text = null;

        [Space]

        [SerializeField]

        private string format = "{0:0.0} ms ({1:0} fps)";

        [Space]

        [SerializeField]

        private BoolPrefs displayFrameRate = new("Display Frame Rate", false);

        public BoolPrefs DisplayFrameRate => displayFrameRate;

        private float time = 0f;

        private float ms;

        private float fps;

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                displayFrameRate.OnValueChanged();
            }
        }

        private void Awake()
        {
            ISingleton<FrameRateDisplayer>.TrySetInstance(this);

            displayFrameRate.ActionOnValueChanged += (value) =>
            {
                gameObject.SetActive(value);
            };

            displayFrameRate.TryLoadValue();
        }

        private void Update()
        {
            time += (Time.unscaledDeltaTime - time) * 0.1f;

            ms = 1000f * time;

            fps = 1f / time;

            text.text = string.Format(format, ms, fps);
        }

        private void OnDestroy()
        {
            ISingleton<FrameRateDisplayer>.Release(this);
        }
    }
}