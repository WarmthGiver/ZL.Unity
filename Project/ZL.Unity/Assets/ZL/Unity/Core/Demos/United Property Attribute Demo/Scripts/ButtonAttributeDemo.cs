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

        [DrawField]

        [Interval]

        [Comment("[Button(\"PrintText\")]")]

        [Button("PrintText")]

        [Interval]

        [Comment("[Button(\"PrintText\", \"PRINT TEXT\")]")]

        [Button("PrintText", "PRINT TEXT")]

        [Interval]

        [Comment("[Button(\"PrintText\", 36f)]")]

        [Button("PrintText", 36f)]

        [Interval]

        [Comment("[Button(\"PrintText\", \"PRINT TEXT\", 36f)]")]

        [Button("PrintText", "PRINT TEXT", 36f)]

        [Interval]

        [Comment("[Button(null)]")]

        [Button(null)]

        [Interval]

        [Comment("[Button(\"print text\")]")]

        [Button("print text")]

        public string text = "Hello, World!";

        public void PrintText()
        {
            FixedDebug.Log(text);
        }
    }
}