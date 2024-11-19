#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Demo
{
    [DisallowMultipleComponent]

    public sealed class HelpBoxAttributeDemo : MonoBehaviour
    {
        [Space]

        [Style(FontStyle.Bold)]

        [Label("Help Box")]

        [Text("Default")]

        [HelpBox("This is message.")]

        public int helpBox;

        [Space]

        [Style(FontStyle.Bold)]

        [Text("Default")]

        [InfoBox("This is message.")]

        [Text("Icon Size = Large")]

        [InfoBox(IconSize.Large, "This is message.")]

        public EmptyClass infoBox;

        [Space]

        [Style(FontStyle.Bold)]

        [Text("Default")]

        [WarningBox("This is message.")]

        [Text("Icon Size = Large")]

        [WarningBox(IconSize.Large, "This is message.")]

        public EmptyClass warningBox;

        [Space]

        [Style(FontStyle.Bold)]

        [Text("Default")]

        [ErrorBox("This is message.")]

        [Text("Icon Size = Large")]

        [ErrorBox(IconSize.Large, "This is message.")]

        public EmptyClass errorBox;
    }
}