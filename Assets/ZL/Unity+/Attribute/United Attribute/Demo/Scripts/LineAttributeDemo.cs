#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Demo
{
    [DisallowMultipleComponent]

    public sealed class LineAttributeDemo : MonoBehaviour
    {
        [Text(128, 128, 128, 255, "Default")]

        [Line]

        [Empty]

        [Text(128, 128, 128, 255, "Color = RGBA(255, 0, 0, 255)")]

        [Line(255, 0, 0, 255)]

        [Empty]

        [Text(128, 128, 128, 255, "Color = RGBA(0, 255, 0, 255)")]

        [Line(0, 255, 0, 255)]

        [Empty]

        [Text(128, 128, 128, 255, "Color = RGBA(0, 0, 255, 255)")]

        [Line(0, 0, 255, 255)]

        [Empty]

        [Text(128, 128, 128, 255, "Height = 2")]

        [Line(2f)]

        [Empty]

        [Text(128, 128, 128, 255, "Height = 3")]

        [Line(3f)]

        [Empty]

        [Text(128, 128, 128, 255, "Full Option")]

        [Line(3f, 255, 0, 255, 255)]

        [HiddenField]

        public EmptyClass empty;
    }
}