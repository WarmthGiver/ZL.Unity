#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Demo
{
    [DisallowMultipleComponent]

    public sealed class ButtonAttributeDemo : MonoBehaviour
	{
        [Space]
        
        [Empty]

        [Text(FontStyle.Italic, "Default")]

        [Button("PrintText")]

        [Empty]

        [Text(FontStyle.Italic, "Text = \"PRINT TEXT\"")]

        [Button("PrintText", "PRINT TEXT")]

        [Empty]

        [Text(FontStyle.Italic, "Height = 36f")]

        [Button(36f, "PrintText")]

        [Empty]

        [Text(FontStyle.Italic, "Full Option")]

        [Button(36f, "PrintText", "PRINT TEXT")]

        [Empty]

        [Text(FontStyle.Italic, "Wrong Method Name*")]

        [Button("printText")]

        public string text = "Hello, World!";

        public void PrintText()
        {
            Fixed.Debug.Log(text);
        }
    }
}