#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    [AddComponentMenu("")]

    public sealed class HelpBoxAttributeDemo : MonoBehaviour
    {
        [Space]

        [Style(FontStyle.Bold)]

        [Label("Help Box")]

        [Empty(2f)]

        [Text("Default")]

        [HelpBox("This is message.")]

        public EmptyClass helpBox;

        [Space]

        [Style(FontStyle.Bold)]

        [Empty(2f)]

        [Text("Default")]

        [InfoBox("This is message.")]

        [Empty(2f)]

        [Text("Icon Size = Large")]

        [InfoBox(IconSize.Large, "This is message.")]

        public EmptyClass infoBox;

        [Space]

        [Style(FontStyle.Bold)]

        [Empty(2f)]

        [Text("Default")]

        [WarningBox("This is message.")]

        [Empty(2f)]

        [Text("Icon Size = Large")]

        [WarningBox(IconSize.Large, "This is message.")]

        public EmptyClass warningBox;

        [Space]

        [Style(FontStyle.Bold)]

        [Empty(2f)]

        [Text("Default")]

        [ErrorBox("This is message.")]

        [Empty(2f)]

        [Text("Icon Size = Large")]

        [ErrorBox(IconSize.Large, "This is message.")]

        public EmptyClass errorBox;
    }
}