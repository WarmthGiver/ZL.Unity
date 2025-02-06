using System;

using System.Collections.Generic;

using System.Reflection;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using Object = UnityEngine.Object;

namespace ZL.Unity
{
    public abstract class UnitedPropertyAttribute : PropertyAttribute
    {
        protected static readonly float defaultLabelHeight;

        protected static readonly float defaultSpaceHeight;

        protected static readonly float defaultIndentWidth;

        protected static readonly float defaultLineHeight;

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

        static UnitedPropertyAttribute()
        {
            defaultLabelHeight = 18f;

            defaultSpaceHeight = 8f;

            defaultIndentWidth = 15f;

            defaultLineHeight = 1f;

            defaultIconSize = IconSize.Small;

            defaultFontSize = EditorStyles.label.fontSize;

            defaultTextColor = EditorStyles.label.normal.textColor;
        }

#if UNITY_EDITOR

        public virtual void Initialize() { }

        public abstract bool Draw(Drawer drawer);

        [CustomPropertyDrawer(typeof(UnitedPropertyAttribute), true)]

        public sealed class Drawer : PropertyDrawer
        {
            private static readonly Dictionary<int, Dictionary<int, Info>> DrawerInfos = new();

            public SerializedProperty Property { get; private set; }

            public Object TargetObject { get; private set; }

            public Component TargetComponent { get; private set; }

            private int instanceID;

            private int hashCode;

            public Info Current { get; private set; }

            private UnitedPropertyAttribute unitedPropertyAttribute;

            private float propertyHeight = 0f;

            ~Drawer()
            {
                if (DrawerInfos.ContainsKey(instanceID) == true)
                {
                    if (DrawerInfos[instanceID].ContainsKey(hashCode) == true)
                    {
                        DrawerInfos[instanceID].Remove(hashCode);

                        if (DrawerInfos[instanceID].Count == 0)
                        {
                            DrawerInfos.Remove(instanceID);
                        }
                    }
                }
            }

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                Property = property;

                if (Current == null)
                {
                    TargetObject = Property.serializedObject.targetObject;

                    TargetComponent = TargetObject as Component;

                    instanceID = TargetComponent.GetInstanceID();

                    hashCode = fieldInfo.GetHashCode();

                    if (DrawerInfos.ContainsKey(instanceID) == false)
                    {
                        DrawerInfos.Add(instanceID, new());

                        DrawerInfos[instanceID].Add(hashCode, new(label));
                    }

                    else if (DrawerInfos[instanceID].ContainsKey(hashCode) == false)
                    {
                        DrawerInfos[instanceID].Add(hashCode, new(label));
                    }

                    Current = DrawerInfos[instanceID][hashCode];

                    unitedPropertyAttribute = (UnitedPropertyAttribute)attribute;

                    unitedPropertyAttribute.Initialize();
                }

                propertyHeight = 0f;

                var enabled = GUI.enabled;

                var indentLevel = EditorGUI.indentLevel;

                unitedPropertyAttribute.Draw(this);

                if (Current.IsToggled == true)
                {
                    Current.PropertyFieldType = SerializedPropertyFieldType.Empty;
                }

                GUI.enabled = Current.IsEnabled;

                EditorGUI.indentLevel = Current.IndentLevel + Current.SubIndentLevel;

                switch (Current.PropertyFieldType)
                {
                    case SerializedPropertyFieldType.Default:

                        EditorGUI.PropertyField(position, Property, Current.Label, true);

                        break;

                    case SerializedPropertyFieldType.Empty:

                        EditorGUI.PropertyField(position, Property, GUIContent.none, false);

                        propertyHeight -= EditorGUI.GetPropertyHeight(Property, Current.Label, true);

                        break;

                    case SerializedPropertyFieldType.Layer:

                        Property.intValue = EditorGUI.LayerField(position, Current.Label, Property.intValue);

                        break;

                    case SerializedPropertyFieldType.Tag:

                        Property.stringValue = EditorGUI.TagField(position, Current.Label, Property.stringValue);

                        if (Property.stringValue == string.Empty)
                        {
                            Property.stringValue = "Untagged";
                        }

                        break;
                }

                EditorGUI.indentLevel = indentLevel;

                GUI.enabled = enabled;
            }

            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                return EditorGUI.GetPropertyHeight(property, label, true) + propertyHeight;
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

            public bool TryFindProperty(string name, SerializedPropertyType propertyType, out SerializedProperty result)
            {
                if (TryFindProperty(name, out result) == false)
                {
                    DrawHelpBox($"{unitedPropertyAttribute.NameTag} No property found matching \"{name}\".", MessageType.Error);

                    return false;
                }

                if (result.propertyType != propertyType)
                {
                    DrawHelpBox($"{unitedPropertyAttribute.NameTag} Property type is mismatch.", MessageType.Error);

                    return false;
                }

                return true;
            }

            public bool TryFindProperty(string name, out SerializedProperty result)
            {
                result = Property.serializedObject.FindProperty(name);

                return result != null;
            }

            public void DrawButton(string methodName, string text, float height)
            {
                var type = TargetObject.GetType();

                MethodInfo method = null;

                if (methodName != null)
                {
                    method = type.GetMethod(methodName);
                }

                var label = new GUIContent(text);

                var style = GUI.skin.button;

                var position = GUILayoutUtility.GetRect(label, style, GUILayout.Height(height));

                position.x += EditorGUIUtility.labelWidth + 2f;

                position.width -= EditorGUIUtility.labelWidth + 2f;

                if (GUI.Button(position, label, style) == true)
                {
                    method.Invoke(TargetObject, null);
                }

                if (method == null)
                {
                    DrawHelpBox($"{unitedPropertyAttribute.NameTag} No method found matching \"{methodName}\".", MessageType.Error);
                }
            }

            public void DrawPreview()
            {
                var texture = AssetPreview.GetAssetPreview(Property.objectReferenceValue);

                if (texture == null)
                {
                    return;
                }

                var label = new GUIContent(texture);

                var style = GUI.skin.label;

                var position = GUILayoutUtility.GetRect(label, style);

                position.x += EditorGUIUtility.labelWidth;

                position.width = texture.width;

                position.height = texture.height;

                EditorGUI.LabelField(position, label);
            }

            public void DrawEmpty(float height)
            {
                DrawLine(height - 1f, Color.clear);
            }

            public void DrawLine(float height, Color color)
            {
                Rect position = EditorGUILayout.GetControlRect(false, height);

                EditorGUI.DrawRect(position, color);
            }

            public void DrawText(GUIContent label, GUIStyle style)
            {
                Rect position = GUILayoutUtility.GetRect(label, style);

                EditorGUI.LabelField(position, label, style);
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
                var style = EditorStyles.helpBox;

                EditorGUILayout.BeginHorizontal();

                var position = GUILayoutUtility.GetRect(label, style, GUILayout.ExpandHeight(true));

                EditorGUI.LabelField(position, label, style);

                EditorGUILayout.EndHorizontal();
            }

            public sealed class Info
            {
                public GUIContent Label { get; private set; }

                public bool IsToggled { get; set; } = false;

                public bool IsEnabled { get; set; }

                public int IndentLevel { get; set; }

                public int SubIndentLevel { get; set; } = 0;

                public SerializedPropertyFieldType PropertyFieldType { get; set; } = SerializedPropertyFieldType.Default;

                public Info(GUIContent label)
                {
                    Label = new(label);

                    IsEnabled = GUI.enabled;

                    IndentLevel = EditorGUI.indentLevel;
                }
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