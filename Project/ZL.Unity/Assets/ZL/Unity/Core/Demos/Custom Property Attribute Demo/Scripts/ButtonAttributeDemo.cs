#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class ButtonAttributeDemo : MonoBehaviour
	{
        [Space]

        [DrawCustomProperty]

        [PropertyField]



        [Margin]

        [Text("[Button(\"PrintText\")]")]

        [Button("PrintText")]



        [Margin]

        [Text("[Button(\"PrintText\", \"PRINT TEXT\")]")]

        [Button("PrintText", "PRINT TEXT")]



        [Margin]

        [Text("[Button(\"PrintText\", Height = 36f)]")]

        [Button("PrintText", Height = 36f)]



        [Margin]

        [Text("[Button(\"PrintText\", \"PRINT TEXT\", Height = 36f)]")]

        [Button("PrintText", "PRINT TEXT", Height = 36f)]



        [Margin]

        [Text("[Button(\"print text\")]")]

        [Button("print text")]



        public string text = "Hello, World!";

        public void PrintText()
        {
            FixedDebug.Log(text);
        }
    }
}