#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class LabelAttributeDemo : MonoBehaviour
    {
        [Space]

        [Label(Text = "Hello World!")]

        [Comment("[Label(Text = \"Hello World!\")]")]

        public string text;

        [Space]

        [Label(Tooltip = "This is tooltip.")]

        [Comment("[Label(Tooltip = \"This is tooltip.\")]")]

        public string tooltip;

        [Space]

        [Label(Text = "Hello World!", Tooltip = "This is tooltip.")]

        [Comment("[Label(Text = \"Hello World!\", Tooltip = \"This is tooltip.\")]")]

        public string textTooltip;
    }
}