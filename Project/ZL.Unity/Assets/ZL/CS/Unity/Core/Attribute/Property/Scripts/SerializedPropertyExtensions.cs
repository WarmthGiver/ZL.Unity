using System;

using UnityEditor;

using UnityEngine;

namespace ZL.CS.Unity
{
    public static partial class SerializedPropertyExtensions
    {
        public static object Unboxing(this SerializedProperty property)
        {
            return property.propertyType switch
            {
                SerializedPropertyType.Integer => (int)property.boxedValue,

                SerializedPropertyType.Boolean => (bool)property.boxedValue,

                SerializedPropertyType.Float => (float)property.boxedValue,

                SerializedPropertyType.String => (string)property.boxedValue,

                SerializedPropertyType.Color => (Color)property.boxedValue,

                SerializedPropertyType.ObjectReference => (UnityEngine.Object)property.boxedValue,

                SerializedPropertyType.LayerMask => (LayerMask)property.boxedValue,

                SerializedPropertyType.Enum => (Enum)property.boxedValue,

                SerializedPropertyType.Vector2 => (Vector2)property.boxedValue,

                SerializedPropertyType.Vector3 => (Vector3)property.boxedValue,

                SerializedPropertyType.Vector4 => (Vector4)property.boxedValue,

                SerializedPropertyType.Rect => (Rect)property.boxedValue,

                SerializedPropertyType.ArraySize => (int)property.boxedValue,

                SerializedPropertyType.Character => (char)property.boxedValue,

                SerializedPropertyType.AnimationCurve => (AnimationCurve)property.boxedValue,

                SerializedPropertyType.Bounds => (Bounds)property.boxedValue,

                SerializedPropertyType.Gradient => (Gradient)property.boxedValue,

                SerializedPropertyType.Quaternion => (Quaternion)property.boxedValue,

                SerializedPropertyType.ExposedReference => (UnityEngine.Object)property.boxedValue,

                SerializedPropertyType.FixedBufferSize => (int)property.boxedValue,

                SerializedPropertyType.Vector2Int => (Vector2Int)property.boxedValue,

                SerializedPropertyType.Vector3Int => (Vector3Int)property.boxedValue,

                SerializedPropertyType.RectInt => (RectInt)property.boxedValue,

                SerializedPropertyType.BoundsInt => (BoundsInt)property.boxedValue,

                _ => property.boxedValue,
            };
        }
    }
}