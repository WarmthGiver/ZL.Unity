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

    public sealed class CommentAttribute : UnitedPropertyAttribute
    {
        private readonly GUIContent label;

        private GUIStyle style;

        public int FontSize { get; set; } = defaultFontSize;

        public FontStyle FontStyle { get; set; } = FontStyle.Italic;

        public float R { get; set; } = 0.5f;

        public float G { get; set; } = 0.5f;

        public float B { get; set; } = 0.5f;

        public float A { get; set; } = 1f;

        public CommentAttribute(string text)
        {
            label = new(text);
        }

#if UNITY_EDITOR

        public override void Initialize()
        {
            style = new(EditorStyles.label);

            style.fontSize = FontSize;

            style.fontStyle = FontStyle;

            style.normal.textColor = new(R, G, B, A);
        }

        public override bool Draw(Drawer drawer)
        {
            

            drawer.DrawText(label, style);

            return true;
        }

#endif
    }
}