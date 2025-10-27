using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Text Controller (Legacy Input Field)")]

    public sealed class TextController_InputField : TextController
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [Alias("Text (UI)")]

        [UsingCustomProperty]

        [SerializeField]

        private InputField textUI = null;

        public override string text
        {
            get => textUI.text;

            set => textUI.text = value;
        }
    }
}