using TMPro;

using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Text Controller (TMP)")]

    [RequireComponent(typeof(TextMeshProUGUI))]

    public sealed class TextController_TMP : TextController<TextMeshProUGUI>
    {
        public override string Text
        {
            get => Target.text;
            
            set => Target.text = value;
        }

        public override void SetText(int value)
        {
            Target.text = value.ToString();
        }

        public override void SetText(float value)
        {
            Target.text = value.ToString();
        }
    }
}