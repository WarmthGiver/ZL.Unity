#if UNITY_EDITOR

using UnityEditor;

using UnityEngine;

public static partial class SerializedObjectExtensions
{
    public static void ScriptField(this SerializedObject instance)
    {
        var enabled = GUI.enabled;

        GUI.enabled = false;

        EditorGUILayout.PropertyField(instance.FindProperty("m_Script"));

        GUI.enabled = enabled;
    }

    public static bool TryFindProperty(this SerializedObject instance, string propertyPath, out SerializedProperty result)
    {
        result = instance.FindProperty(propertyPath);

        return result != null;
    }
}

#endif