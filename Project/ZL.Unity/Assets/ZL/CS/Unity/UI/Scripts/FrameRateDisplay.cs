using TMPro;

using UnityEngine;

namespace ZL.CS.Unity.UI
{
    [RequireComponent(typeof(TMP_Text))]

    public sealed class FrameRateDisplay : MonoBehaviour
    {
        [SerializeField, GetComponent]

        private TMP_Text text;

        [Space]

        [SerializeField]

        private string format = "{0:0.0} ms ({1:0} fps)";

        [SerializeField]

        private float time = 0f;

        private void FixedUpdate()
        {
            time += (Time.unscaledDeltaTime - time) * 0.1f;

            float ms = 1000f * time;

            float fps = 1f / time;

            text.text = string.Format(format, ms, fps);
        }
    }
}