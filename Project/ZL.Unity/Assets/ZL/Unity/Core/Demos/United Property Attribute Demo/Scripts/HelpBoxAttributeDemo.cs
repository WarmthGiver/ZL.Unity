#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class HelpBoxAttributeDemo : MonoBehaviour
    {
        [Space]

        [Label(Text = "Help Box")]

        [Empty(2f)]

        [Comment("Default")]

        [HelpBox("This is message.")]

        public EmptyClass helpBox;

        [Space]

        [Empty(2f)]

        [Comment("Default")]

        [InfoBox("This is info message.")]

        [Empty(2f)]

        [Comment("Icon Size = Large")]

        [InfoBox("This is info message.", IconSize.Large)]

        public EmptyClass infoBox;

        [Space]

        [Empty(2f)]

        [Comment("Default")]

        [WarningBox("This is warning message.")]

        [Empty(2f)]

        [Comment("Icon Size = Large")]

        [WarningBox("This is warning message.", IconSize.Large)]

        public EmptyClass warningBox;

        [Space]

        [Empty(2f)]

        [Comment("Default")]

        [ErrorBox("This is error message.")]

        [Empty(2f)]

        [Comment("Icon Size = Large")]

        [ErrorBox("This is error message.", IconSize.Large)]

        public EmptyClass errorBox;
    }
}