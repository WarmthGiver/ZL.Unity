#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class TextAttributeDemo : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [Comment("Hello World!")]

        [Comment("[Comment(\"Hello World!\")]")]

        private EmptyClass @default;

        [Space]

        [SerializeField]

        [Comment("Hello World!", R = 1f, G = 0f, B = 0f)]

        [Comment("[Comment(\"Hello World!\", R = 1f, G = 0f, B = 0f)]")]

        private EmptyClass colorRed;

        [Space]

        [SerializeField]

        [Comment("Hello World!", R = 0f, G = 1f, B = 0f)]

        [Comment("[Comment(\"Hello World!\", R = 0f, G = 1f, B = 0f)]")]

        private EmptyClass colorGreen;

        [Space]

        [SerializeField]

        [Comment("Hello World!", R = 0f, G = 0f, B = 1f)]

        [Comment("[Comment(\"Hello World!\", R = 0f, G = 0f, B = 1f)]")]

        private EmptyClass colorBlue;

        [Space]

        [SerializeField]

        [Comment("Hello World!", FontStyle = FontStyle.Normal)]

        [Comment("[Comment(\"Hello World!\", FontStyle = FontStyle.Normal)]")]

        private EmptyClass fontStyleNormal;

        [Space]

        [SerializeField]

        [Comment("Hello World!", FontStyle = FontStyle.Bold)]

        [Comment("[Comment(\"Hello World!\", FontStyle = FontStyle.Bold)]")]

        private EmptyClass fontStyleBold;

        [Space]

        [SerializeField]

        [Comment("Hello World!", FontStyle = FontStyle.BoldAndItalic)]

        [Comment("[Comment(\"Hello World!\", FontStyle = FontStyle.BoldAndItalic)]")]

        private EmptyClass fontStyleBoldAndItalic;

        [Space]

        [SerializeField]

        [Comment("Hello World!", FontSize = 24)]

        [Comment("[Comment(\"Hello World!\", FontSize = 24)]")]

        private EmptyClass fontSize24;

        [Space]

        [SerializeField]

        [Comment("Hello World!", FontSize = 36)]

        [Comment("[Comment(\"Hello World!\", FontSize = 36)]")]

        private EmptyClass fontSize36;

        [Space]

        [SerializeField]

        [Comment("Hello World!", FontSize = 36, FontStyle = FontStyle.BoldAndItalic, R = 1f, G = 0f, B = 1f)]

        [Comment("[Comment(\"Hello World!\", FontSize = 36, FontStyle = FontStyle.BoldAndItalic, R = 1f, G = 0f, B = 1f)]")]

        private EmptyClass fullOptions;
    }
}