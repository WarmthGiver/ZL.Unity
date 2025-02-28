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
        protected const int defaultSpaceHeight = 8;

        protected const float defaultLabelHeight = 18f;

        protected const int defaultFontSize = 12;

        protected static readonly Color defaultTextColor;

        protected static readonly GUIStyle defaultLabelStyle;

#if UNITY_EDITOR

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
            if (EditorGUIUtility.isProSkin == true)
            {
                defaultTextColor = new(0.769f, 0.769f, 0.769f, 1f);
            }
            
            else
            {
                defaultTextColor = new(0.035f, 0.035f, 0.03f, 1f);
            }

            defaultLabelStyle = new()
            {
                fontSize = defaultFontSize,
            };
            
            defaultLabelStyle.normal.textColor = defaultTextColor;
        }

        protected virtual void Initialize(Drawer drawer) { }

        protected virtual void Preset(Drawer drawer) { }

        protected virtual void Draw(Drawer drawer) { }

        [CustomPropertyDrawer(typeof(UsingCustomPropertyAttribute), true)]

        public sealed class Drawer : PropertyDrawer
        {
            private Rect drawPosition;

            private float propertyHeight;

            public SerializedProperty Property { get; private set; }

            public GUIContent PropertyLabel { get; private set; }

            public Component TargetComponent { get; private set; } = null;

            private IEnumerable<CustomPropertyAttribute> attributes = null;

            public bool IsToggled { get; set; }

            public bool IsEnabled { get; set; }

            public int IndentLevel { get; set; }

            public bool IsPropertyFieldDrawn { get; set; }

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                drawPosition = position;

                propertyHeight = -2f;

                Property = property;

                PropertyLabel = label;

                if (TargetComponent == null)
                {
                    TargetComponent = property.serializedObject.targetObject as Component;

                    attributes = fieldInfo.GetCustomAttributes<CustomPropertyAttribute>();

                    foreach (var attribute in attributes)
                    {
                        attribute.Initialize(this);
                    }
                }

                IsToggled = false;

                var enabled = IsEnabled = GUI.enabled;

                var indentLevel = IndentLevel = EditorGUI.indentLevel;

                IsPropertyFieldDrawn = false;

                foreach (var attribute in attributes)
                {
                    attribute.Preset(this);

                    if (IsToggled == true)
                    {
                        continue;
                    }

                    attribute.Draw(this);

                    GUI.enabled = IsEnabled;

                    EditorGUI.indentLevel = IndentLevel;
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

            public void DrawPropertyField()
            {
                EditorGUI.PropertyField(drawPosition, Property, PropertyLabel, true);

                Margin(EditorGUI.GetPropertyHeight(Property, PropertyLabel, true) + 2f);
            }

            public void DrawLayerField()
            {
                Property.intValue = EditorGUI.LayerField(drawPosition, PropertyLabel, Property.intValue);

                Margin(defaultLabelHeight + 2f);
            }

            public void DrawTagField()
            {
                Property.stringValue = EditorGUI.TagField(drawPosition, PropertyLabel, Property.stringValue);

                Margin(defaultLabelHeight + 2f);
            }

            public void DrawLabelField()
            {
                DrawText(PropertyLabel);
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

            public void DrawLine(int margin, int thickness, Color color)
            {
                var rect = drawPosition;

                rect.y += margin;

                rect.height = thickness;

                EditorGUI.DrawRect(rect, color);

                Margin((margin << 1) + thickness);
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

                position.height = EditorStyles.helpBox.CalcHeight(new GUIContent(message), position.width);

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

#endif
    }
}