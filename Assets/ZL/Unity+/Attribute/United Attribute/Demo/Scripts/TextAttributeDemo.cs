#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Demo
{
    [DisallowMultipleComponent]

    public sealed class TextAttributeDemo : MonoBehaviour
    {
        [Text(128, 128, 128, 255, "Default")]

        [Text("Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Font Style = Bold")]

        [Text(FontStyle.Bold, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Font Style = Italic")]

        [Text(FontStyle.Italic, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Font Style = Bold And Italic")]

        [Text(FontStyle.BoldAndItalic, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Color = RGBA(255, 0, 0, 255)")]

        [Text(255, 0, 0, 255, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Color = RGBA(0, 255, 0, 255)")]

        [Text(0, 255, 0, 255, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Color = RGBA(0, 0, 255, 255)")]

        [Text(0, 0, 255, 255, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Font Size = 24")]

        [Text(24, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Font Size = 36")]

        [Text(36, "Hello World!")]

        [Empty]

        [Text(128, 128, 128, 255, "Full Option")]

        [Text(36, FontStyle.BoldAndItalic, 255, 0, 255, 255, "Hello World!")]

        [HiddenField]

        public EmptyClass hidden;
    }
}