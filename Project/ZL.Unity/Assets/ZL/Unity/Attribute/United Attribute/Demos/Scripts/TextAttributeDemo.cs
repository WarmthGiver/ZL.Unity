#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    [DisallowMultipleComponent]

    public sealed class TextAttributeDemo : MonoBehaviour
    {
        [Text("Default")]

        [Text("Hello World!")]

        [Empty]

        [Text("Font Style = Bold")]

        [Text(FontStyle.Bold, "Hello World!")]

        [Empty]

        [Text("Font Style = Italic")]

        [Text("Hello World!")]

        [Empty]

        [Text("Font Style = Bold And Italic")]

        [Text(FontStyle.BoldAndItalic, "Hello World!")]

        [Empty]

        [Text("Color = RGBA(255, 0, 0, 255)")]

        [Text(255, 0, 0, 255, "Hello World!")]

        [Empty]

        [Text("Color = RGBA(0, 255, 0, 255)")]

        [Text(0, 255, 0, 255, "Hello World!")]

        [Empty]

        [Text("Color = RGBA(0, 0, 255, 255)")]

        [Text(0, 0, 255, 255, "Hello World!")]

        [Empty]

        [Text("Font Size = 24")]

        [Text(24, "Hello World!")]

        [Empty]

        [Text("Font Size = 36")]

        [Text(36, "Hello World!")]

        [Empty]

        [Text("Full Option")]

        [Text(36, FontStyle.BoldAndItalic, 255, 0, 255, 255, "Hello World!")]

        [HiddenField]

        public EmptyClass hidden;
    }
}