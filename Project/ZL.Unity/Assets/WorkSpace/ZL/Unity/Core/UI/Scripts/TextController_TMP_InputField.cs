using TMPro;

using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Text Controller (TMP Input Field)")]

    [RequireComponent(typeof(TMP_InputField))]

    public sealed class TextController_TMP_InputField : TextController<TMP_InputField>
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