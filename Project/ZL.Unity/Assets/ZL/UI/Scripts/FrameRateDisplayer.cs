using UnityEngine;

using ZL.Unity.IO;

using ZL.Unity.Singleton;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Frame Rate Displayer (Singleton)")]

    public sealed class FrameRateDisplayer : MonoSingleton<FrameRateDisplayer>
    {
        [Space]

        [Essential]

        [ReadOnlyIfPlayMode(true)]

        [UsingCustomProperty]

        [SerializeField]

        private TextController textController = null;

        [Space]

        [SerializeField]

        private string format = "{0:0.0} ms ({1:0} fps)";

        [Space]

        [PropertyField]

        [AddIndent(3)]

        [Button(nameof(Load))]

        [Button(nameof(Save))]

        [UsingCustomProperty]

        [SerializeField]

        private BoolPref displayFrameRatePref = new("DisplayFrameRate", true);

        private float time = 0f;

        private float ms;

        private float fps;

        #if UNITY_EDITOR

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                displayFrameRatePref.Value = displayFrameRatePref.Value;
            }
        }

        #endif

        protected override void Awake()
        {
            base.Awake();

            displayFrameRatePref.OnValueChanged += (value) =>
            {
                gameObject.SetActive(value);
            };

            displayFrameRatePref.TryLoadValue();
        }

        private void Update()
        {
            time += (Time.unscaledDeltaTime - time) * 0.1f;

            ms = 1000f * time;

            fps = 1f / time;

            textController.text = string.Format(format, ms, fps);
        }

        public void Load()
        {
            displayFrameRatePref.LoadValue();
        }

        public void Save()
        {
            displayFrameRatePref.SaveValue();
        }
    }
}