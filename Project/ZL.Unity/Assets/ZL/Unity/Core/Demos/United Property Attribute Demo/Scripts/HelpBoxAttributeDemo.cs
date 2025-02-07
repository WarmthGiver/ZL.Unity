#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class HelpBoxAttributeDemo : MonoBehaviour
    {
        [Space]

        [Label("Help Box")]

        [Interval(2f)]

        [Comment("Default")]

        [HelpBox("This is message.")]

        public EmptyClass helpBox;

        [Space]

        [Interval(2f)]

        [Comment("Default")]

        [InfoBox("This is info message.")]

        [Interval(2f)]

        [Comment("Icon Size = Large")]

        [InfoBox("This is info message.", IconSize.Large)]

        public EmptyClass infoBox;

        [Space]

        [Interval(2f)]

        [Comment("Default")]

        [WarningBox("This is warning message.")]

        [Interval(2f)]

        [Comment("Icon Size = Large")]

        [WarningBox("This is warning message.", IconSize.Large)]

        public EmptyClass warningBox;

        [Space]

        [Interval(2f)]

        [Comment("Default")]

        [ErrorBox("This is error message.")]

        [Interval(2f)]

        [Comment("Icon Size = Large")]

        [ErrorBox("This is error message.", IconSize.Large)]

        public EmptyClass errorBox;
    }
}