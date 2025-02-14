using System;

using System.Collections.Generic;

using System.Reflection;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]

    public abstract class CustomPropertyAttribute : PropertyAttribute
    {
        protected static readonly int defaultSpaceHeight;

        protected static readonly float defaultLabelHeight;

        protected static readonly GUIStyle defaultLabelStyle;

        protected static readonly int defaultFontSize;

        protected static readonly Color defaultTextColor;

        private string nameTag = null;

        public string NameTag
        {
            get
            {
                nameTag ??= $"[{GetType().Name.RemoveFromBehind("Attribute")}]";

                return nameTag;
            }
        }

        static CustomPropertyAttribute()
        {
            defaultSpaceHeight = 8;

            defaultLabelHeight = 18f;

            defaultLabelStyle = EditorStyles.label;

            defaultFontSize = defaultLabelStyle.fontSize;

            defaultTextColor = defaultLabelStyle.normal.textColor;
        }

#if UNITY_EDITOR

        protected virtual void Initialize(Drawer drawer) { }

        protected virtual void Preset(Drawer drawer) { }

        protected virtual void Draw(Drawer drawer) { }

        [CustomPropertyDrawer(typeof(UsingCustomPropertyAttribute), true)]

        public sealed class Drawer : PropertyDrawer
        {
            public Component TargetComponent { get; private set; } = null;

            private IEnumerable<CustomPropertyAttribute> attributes = null;


            private Rect drawPosition;

            private float propertyHeight;

            public SerializedProperty Property { get; private set; }

            public GUIContent PropertyLabel { get; private set; }

            public bool IsToggled { get; set; }

            public bool IsEnabled { get; set; }

            public int IndentLevel { get; set; }

            public bool IsPropertyFieldDrawn { get; set; }

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                if (TargetComponent == null)
                {
                    TargetComponent = property.serializedObject.targetObject as Component;

                    attributes = fieldInfo.GetCustomAttributes<CustomPropertyAttribute>();

                    foreach (var attribute in attributes)
                    {
                        attribute.Initialize(this);
                    }
                }

                drawPosition = position;

                propertyHeight = -2f;

                Property = property;

                PropertyLabel = label;

                IsToggled = false;

                var enabled = IsEnabled = GUI.enabled;

                var indentLevel = IndentLevel = EditorGUI.indentLevel;

                IsPropertyFieldDrawn = false;

                foreach (var attribute in attributes)
                {
                    attribute.Preset(this);

                    GUI.enabled = IsEnabled;

                    EditorGUI.indentLevel = IndentLevel;

                    if (IsToggled == true)
                    {
                        continue;
                    }

                    attribute.Draw(this);
                }

                if (IsPropertyFieldDrawn == false && IsToggled == false)
                {
                    DrawPropertyField();
                }

                GUI.enabled = enabled;

                EditorGUI.indentLevel = indentLevel;
            }

            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                return propertyHeight;
            }

            public void DrawPropertyField(SerializedPropertyFieldType propertyFieldType = SerializedPropertyFieldType.Property)
            {
                switch (propertyFieldType)
                {
                    case SerializedPropertyFieldType.Property:

                        EditorGUI.PropertyField(drawPosition, Property, PropertyLabel, true);

                        break;

                    case SerializedPropertyFieldType.Layer:

                        Property.intValue = EditorGUI.LayerField(drawPosition, PropertyLabel, Property.intValue);

                        break;

                    case SerializedPropertyFieldType.Tag:

                        Property.stringValue = EditorGUI.TagField(drawPosition, PropertyLabel, Property.stringValue);

                        break;

                    case SerializedPropertyFieldType.Empty:

                        return;
                }

                float height = EditorGUI.GetPropertyHeight(Property, PropertyLabel, true);

                Margin(height + 2f);
            }

            public void DrawButton(MethodInfo method, string text, float height)
            {
                var position = drawPosition;

                position.x += EditorGUIUtility.labelWidth + 2f;

                position.width -= EditorGUIUtility.labelWidth + 2f;

                position.height = height;

                if (GUI.Button(position, text) == true)
                {
                    method.Invoke(TargetComponent, null);
                }

                Margin(height + 2f);
            }

            public void DrawPreview()
            {
                var texture = AssetPreview.GetAssetPreview(Property.objectReferenceValue);

                if (texture == null)
                {
                    return;
                }

                var label = new GUIContent(texture);

                var position = drawPosition;

                position.y -= 1f;

                position.x += EditorGUIUtility.labelWidth + 1f;

                float height = Math.Max(texture.width, texture.height);

                position.width = height;

                position.height = height;

                EditorGUI.LabelField(position, label);

                Margin(height);
            }

            public void DrawLine(int margin, int thickness, Color color)
            {
                var rect = drawPosition;

                rect.y += margin;

                rect.height = thickness;

                EditorGUI.DrawRect(rect, color);

                Margin((margin << 1) + thickness);
            }

            public void DrawText(GUIContent label)
            {
                DrawText(defaultLabelStyle.CalcSize(label).y, label, defaultLabelStyle);
            }

            public void DrawText(GUIContent label, GUIStyle style)
            {
                DrawText(style.CalcSize(label).y, label, style);
            }

            public void DrawText(float height, GUIContent label)
            {
                DrawText(height, label, defaultLabelStyle);
            }

            public void DrawText(float height, GUIContent label, GUIStyle style)
            {
                Rect position = drawPosition;

                position.height = height;

                EditorGUI.LabelField(position, label, style);

                Margin(position.height + 2f);
            }

            public void DrawMessageBox(string message)
            {
                DrawHelpBox(message, MessageType.None);
            }

            public void DrawInfoBox(string message)
            {
                DrawHelpBox(message, MessageType.Info);
            }

            public void DrawWarningBox(string message)
            {
                DrawHelpBox(message, MessageType.Warning);
            }

            public void DrawErrorBox(string message)
            {
                DrawHelpBox(message, MessageType.Error);
            }

            private void DrawHelpBox(string message, MessageType type)
            {
                var position = drawPosition;

                position.height = GUI.skin.GetStyle("HelpBox").CalcHeight(new GUIContent(message), position.width);

                EditorGUI.HelpBox(position, message, type);

                Margin(position.height + 2f);
            }

            public void Indent(float width)
            {
                drawPosition.x += width;

                drawPosition.width -= width;
            }

            public void Margin(float height)
            {
                drawPosition.y += height;

                propertyHeight += height;
            }
        }

        public enum SerializedPropertyFieldType
        {
            Property,

            Layer,

            Tag,

            Empty,
        }

#endif
    }
}