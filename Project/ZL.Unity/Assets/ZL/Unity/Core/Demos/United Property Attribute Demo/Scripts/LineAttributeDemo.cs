#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    [AddComponentMenu("")]

    public sealed class LineAttributeDemo : MonoBehaviour
    {
        [Text("Default")]

        [Line]

        [Empty]

        [Text("Color = RGBA(255, 0, 0, 255)")]

        [Line(255, 0, 0, 255)]

        [Empty]

        [Text("Color = RGBA(0, 255, 0, 255)")]

        [Line(0, 255, 0, 255)]

        [Empty]

        [Text("Color = RGBA(0, 0, 255, 255)")]

        [Line(0, 0, 255, 255)]

        [Empty]

        [Text("Height = 2")]

        [Line(2f)]

        [Empty]

        [Text("Height = 3")]

        [Line(3f)]

        [Empty]

        [Text("Full Option")]

        [Line(3f, 255, 0, 255, 255)]

        [HiddenField]

        public EmptyClass empty; 
    }
}