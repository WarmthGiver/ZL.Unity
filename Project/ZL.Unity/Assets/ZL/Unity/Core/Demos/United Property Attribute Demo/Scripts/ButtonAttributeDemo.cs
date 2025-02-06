#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class ButtonAttributeDemo : MonoBehaviour
	{
        [Space]
        
        [Empty]

        [Comment("Default")]

        [Button(nameof(PrintText))]

        [Empty]

        [Comment("Text = \"PRINT TEXT\"")]

        [Button(nameof(PrintText), Text = "PRINT TEXT")]

        [Empty]

        [Comment("Height = 36f")]

        [Button(nameof(PrintText), Height = 36f)]

        [Empty]

        [Comment("Full Option")]

        [Button(nameof(PrintText), Text = "PRINT TEXT", Height = 36f)]

        [Empty]

        [Comment("Wrong Method Name*")]

        [Button("printText")]

        public string text = "Hello, World!";

        public void PrintText()
        {
            FixedDebug.Log(text);
        }
    }
}