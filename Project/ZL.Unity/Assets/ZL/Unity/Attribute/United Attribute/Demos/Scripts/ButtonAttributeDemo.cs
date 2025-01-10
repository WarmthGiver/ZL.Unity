#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    [DisallowMultipleComponent]

    public sealed class ButtonAttributeDemo : MonoBehaviour
	{
        [Space]
        
        [Empty]

        [Text("Default")]

        [Button("PrintText")]

        [Empty]

        [Text("Text = \"PRINT TEXT\"")]

        [Button("PrintText", "PRINT TEXT")]

        [Empty]

        [Text("Height = 36f")]

        [Button(36f, "PrintText")]

        [Empty]

        [Text("Full Option")]

        [Button(36f, "PrintText", "PRINT TEXT")]

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