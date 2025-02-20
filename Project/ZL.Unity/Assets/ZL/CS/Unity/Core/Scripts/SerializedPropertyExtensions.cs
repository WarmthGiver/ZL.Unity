#if UNITY_EDITOR

using UnityEditor;

public static partial class SerializedPropertyExtensions
{
    public static bool TryFindProperty(this SerializedProperty instance, string propertyPath, out SerializedProperty result)
    {
        return instance.serializedObject.TryFindProperty(propertyPath, out result);
    }

    public static bool IsPropertyTypeIn(this SerializedProperty instance, params SerializedPropertyType[] propertyTypes)
    {
        foreach (var propertyType in propertyTypes)
        {
            if (instance.propertyType == propertyType)
            {
                return true;
            }
        }

        return false;
    }
}

#endif