using System;

using System.Collections.Generic;

using System.Reflection;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace ZL.Unity
{
    public abstract class CustomPropertyAttribute : PropertyAttribute
    {
        protected static readonly float defaultLabelHeight;

        protected static readonly float defaultIndentWidth;

        protected static readonly float defaultIntervalHeight;

        protected static readonly IconSize defaultIconSize;

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
            defaultLabelHeight = 18f;

            defaultIndentWidth = 15f;

            defaultIntervalHeight = 8f;

            defaultIconSize = IconSize.Small;

            defaultFontSize = EditorStyles.label.fontSize;

            defaultTextColor = EditorStyles.label.normal.textColor;
        }

#if UNITY_EDITOR

        public virtual void Initialize(Drawer drawer) { }

        public abstract bool Draw(Drawer drawer);

        [CustomPropertyDrawer(typeof(DrawFieldAttribute), true)]

        public sealed class Drawer : PropertyDrawer
        {
            private IEnumerable<CustomPropertyAttribute> attributes = null;

            private Rect drawPosition;

            private float propertyHeight;

            public SerializedProperty Property { get; private set; }

            public Component TargetComponent { get; private set; } = null;

            public GUIContent Label { get; private set; }

            public bool IsHided { get; set; }

            public bool IsEnabled { get; set; }

            public SerializedPropertyFieldStyle style { get; set; }

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                if (attributes == null)
                {
                    attributes = fieldInfo.GetCustomAttributes<CustomPropertyAttribute>();
                }

                drawPosition = position;

                propertyHeight = 0f;

                Property = property;

                TargetComponent = property.serializedObject.targetObject as Component;

                Label = label;

                IsHided = false;

                var enabled = IsEnabled = GUI.enabled;

                style = SerializedPropertyFieldStyle.Default;

                foreach (var attribute in attributes)
                {
                    attribute.Initialize(this);

                    GUI.enabled = IsEnabled;

                    if (IsHided == false)
                    {
                        attribute.Draw(this);
                    }
                }

                GUI.enabled = enabled;
            }

            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                return propertyHeight;
            }

            public void DrawField()
            {
                switch (style)
                {
                    case SerializedPropertyFieldStyle.Default:

                        EditorGUI.PropertyField(drawPosition, Property, Label, true);

                        break;

                    case SerializedPropertyFieldStyle.Empty:

                        EditorGUI.PropertyField(drawPosition, Property, GUIContent.none, false);

                        return;

                    case SerializedPropertyFieldStyle.Layer:

                        Property.intValue = EditorGUI.LayerField(drawPosition, Label, Property.intValue);

                        break;

                    case SerializedPropertyFieldStyle.Tag:

                        Property.stringValue = EditorGUI.TagField(drawPosition, Label, Property.stringValue);

                        if (Property.stringValue == string.Empty)
                        {
                            Property.stringValue = "Untagged";
                        }

                        break;
                }

                float height = EditorGUI.GetPropertyHeight(Property, Label, true); ;

                Interval(height);
            }

            public bool IsFieldTypeIn(params Type[] types)
            {
                if (fieldInfo.FieldType.IsIncludedIn(types) == true)
                {
                    return true;
                }

                if (fieldInfo.FieldType.IsSubclassIn(types) == true)
                {
                    return true;
                }

                return false;
            }

            public bool IsPropertyTypeIn(params SerializedPropertyType[] propertyTypes)
            {
                foreach (var propertyType in propertyTypes)
                {
                    if (Property.propertyType == propertyType)
                    {
                        return true;
                    }
                }

                return false;
            }

            public bool IsPropertyNull()
            {
                return Property.objectReferenceValue == null;
            }

            public bool TryFindProperty(string propertyPath, out SerializedProperty result)
            {
                result = Property.serializedObject.FindProperty(propertyPath);

                return result != null;
            }

            public void DrawButton(string methodName, string text, float height)
            {
                var type = TargetComponent.GetType();

                MethodInfo method = null;

                if (methodName != null)
                {
                    method = type.GetMethod(methodName);
                }

                var position = drawPosition;

                position.x += EditorGUIUtility.labelWidth + 2f;

                position.y += 2f;

                position.width -= EditorGUIUtility.labelWidth + 2f;

                position.height = height;

                if (GUI.Button(position, text) == true)
                {
                    method.Invoke(TargetComponent, null);
                }

                if (method == null)
                {
                    //DrawHelpBox($"{customPropertyAttributes.NameTag} No method found matching \"{methodName}\".", MessageType.Error);
                }

                Interval(height + 2f);
            }

            public void DrawPreview()
            {
                var texture = AssetPreview.GetAssetPreview(Property.objectReferenceValue);

                if (texture == null)
                {
                    return;
                }

                var label = new GUIContent(texture);

                var position = GUILayoutUtility.GetRect(label, GUI.skin.label);

                position.x += EditorGUIUtility.labelWidth;

                position.y += 2f;

                position.width = texture.width;

                position.height = texture.height;

                EditorGUI.LabelField(position, label);

                Interval(texture.height + 2f);
            }

            public void DrawLine(float height, Color color)
            {
                var rect = drawPosition;

                rect.y += 2f;

                rect.height = height;

                EditorGUI.DrawRect(rect, color);

                Interval(height + 4f);
            }

            public void DrawText(GUIContent label, GUIStyle style)
            {
                Rect position = drawPosition;

                position.y += 2f;

                position.size = style.CalcSize(label);

                EditorGUI.LabelField(position, label, style);

                Interval(position.height + 2f);
            }

            public void DrawHelpBox(string message, MessageType type)
            {
                DrawHelpBox(message, type, defaultIconSize);
            }

            public void DrawHelpBox(string message, MessageType type, IconSize iconSize)
            {
                DrawHelpBox(new GUIContent(message, Utility.GetHelpIcon(type, iconSize)));
            }

            public void DrawHelpBox(GUIContent label)
            {
                /*var style = EditorStyles.helpBox;

                EditorGUILayout.BeginHorizontal();

                var position = GUILayoutUtility.GetRect(label, style, GUILayout.ExpandHeight(true));

                EditorGUI.LabelField(position, label, style);

                EditorGUILayout.EndHorizontal();*/

                EditorGUI.HelpBox(drawPosition);
            }

            public void Indent(float width)
            {
                drawPosition.x += width;

                drawPosition.width -= width;
            }

            public void Interval(float height)
            {
                drawPosition.y += height;

                propertyHeight += height;
            }
        }

        protected static class Utility
        {
            private static Texture2D smallInfoIcon = null;

            public static Texture2D SmallInfoIcon
            {
                get
                {
                    if (smallInfoIcon == null)
                    {
                        smallInfoIcon = LargeInfoIcon.ResizeTo(16, 16);
                    }

                    return smallInfoIcon;
                }
            }

            private static Texture2D largeInfoIcon = null;

            public static Texture2D LargeInfoIcon
            {
                get
                {
                    if (largeInfoIcon == null)
                    {
                        largeInfoIcon = EditorGUIUtility.FindTexture("console.infoicon@2x");
                    }

                    return largeInfoIcon;
                }
            }

            private static Texture2D smallWarningIcon = null;

            public static Texture2D SmallWarningIcon
            {
                get
                {
                    if (smallWarningIcon == null)
                    {
                        smallWarningIcon = LargeWarningIcon.ResizeTo(16, 16);
                    }

                    return smallWarningIcon;
                }
            }

            private static Texture2D largeWarningIcon = null;

            public static Texture2D LargeWarningIcon
            {
                get
                {
                    if (largeWarningIcon == null)
                    {
                        largeWarningIcon = EditorGUIUtility.FindTexture("console.warnicon@2x");
                    }

                    return largeWarningIcon;
                }
            }

            private static Texture2D smallErrorIcon = null;

            public static Texture2D SmallErrorIcon
            {
                get
                {
                    if (smallErrorIcon == null)
                    {
                        smallErrorIcon = LargeErrorIcon.ResizeTo(16, 16); ;
                    }

                    return smallErrorIcon;
                }
            }

            private static Texture2D largeErrorIcon = null;

            public static Texture2D LargeErrorIcon
            {
                get
                {
                    if (largeErrorIcon == null)
                    {
                        largeErrorIcon = EditorGUIUtility.FindTexture("console.erroricon@2x");
                    }

                    return largeErrorIcon;
                }
            }

            public static Texture2D GetHelpIcon(MessageType type, IconSize size)
            {
                return type switch
                {
                    MessageType.Info => GetInfoIcon(size),

                    MessageType.Warning => GetWarningIcon(size),

                    MessageType.Error => GetErrorIcon(size),

                    _ => null
                };
            }

            public static Texture2D GetInfoIcon(IconSize size)
            {
                return size switch
                {
                    IconSize.Small => SmallInfoIcon,

                    IconSize.Large => LargeInfoIcon,

                    _ => null
                };
            }

            public static Texture2D GetWarningIcon(IconSize size)
            {
                return size switch
                {
                    IconSize.Small => SmallWarningIcon,

                    IconSize.Large => LargeWarningIcon,

                    _ => null
                };
            }

            public static Texture2D GetErrorIcon(IconSize size)
            {
                return size switch
                {
                    IconSize.Small => SmallErrorIcon,

                    IconSize.Large => LargeErrorIcon,

                    _ => null
                };
            }
        }

#endif
    }
}