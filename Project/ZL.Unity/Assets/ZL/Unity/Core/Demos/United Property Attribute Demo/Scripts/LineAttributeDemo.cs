#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class LineAttributeDemo : MonoBehaviour
    {
        [Space]

        [Comment("Default")]

        [Line]

        [Empty]

        [Comment("R = 1f, G = 0f, B = 0f")]

        [Line(R = 1f, G = 0f, B = 0f)]

        [Empty]

        [Comment("R = 0f, G = 1f, B = 0f")]

        [Line(R = 0f, G = 1f, B = 0f)]

        [Empty]

        [Comment("R = 0f, G = 0f, B = 1f")]

        [Line(R = 0f, G = 0f, B = 1f)]

        [Empty]

        [Comment("Height = 2")]

        [Line(Height = 2f)]

        [Empty]

        [Comment("Height = 3")]

        [Line(Height = 3f)]

        [Empty]

        [Comment("Height = 3f, R = 1f, G = 0f, B = 1f")]

        [Line(Height = 3f, R = 1f, G = 0f, B = 1f) ]

        [Hidden]

        public EmptyClass empty; 
    }
}