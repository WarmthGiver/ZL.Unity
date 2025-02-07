using System;

using System.Diagnostics;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    [Conditional("UNITY_EDITOR")]

    public sealed class CommentAttribute : CustomPropertyAttribute
    {
        private readonly GUIContent label;

        private readonly GUIStyle style;

        private static readonly int fontSize = defaultFontSize;

        private static readonly FontStyle fontStyle = FontStyle.Italic;

        private static readonly string hexColor = "#808080ff";

        public CommentAttribute(string text) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, string hexColor) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, FontStyle fontStyle) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, FontStyle fontStyle, string hexColor) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, int fontSize) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, int fontSize, string hexColor) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, int fontSize, FontStyle fontStyle) : this(text, fontSize, fontStyle, hexColor) { }

        public CommentAttribute(string text, int fontSize, FontStyle fontStyle, string hexColor)
        {
            label = new(text);

            style = new(EditorStyles.label)
            {
                fontSize = fontSize,

                fontStyle = fontStyle
            };

            if (ColorUtility.TryParseHtmlString(hexColor, out Color textColor) == true)
            {
                style.normal.textColor = textColor;
            }
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawText(label, style);

            return true;
        }

#endif
    }
}