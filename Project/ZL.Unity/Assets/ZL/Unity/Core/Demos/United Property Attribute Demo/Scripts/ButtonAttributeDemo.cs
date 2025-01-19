#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    [AddComponentMenu("")]

    public sealed class ButtonAttributeDemo : MonoBehaviour
	{
        [Space]
        
        [Empty]

        [Text("Default")]

        [Button(nameof(PrintText))]

        [Empty]

        [Text("Text = \"PRINT TEXT\"")]

        [Button(nameof(PrintText), "PRINT TEXT")]

        [Empty]

        [Text("Height = 36f")]

        [Button(nameof(PrintText), 36f)]

        [Empty]

        [Text("Full Option")]

        [Button(nameof(PrintText), "PRINT TEXT", 36f)]

        [Empty]

        [Text("Wrong Method Name*")]

        [Button("printText")]

        public string text = "Hello, World!";

        public void PrintText()
        {
            FixedDebug.Log(text);
        }
    }
}