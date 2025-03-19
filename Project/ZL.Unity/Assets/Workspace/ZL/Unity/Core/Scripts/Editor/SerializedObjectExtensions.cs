using UnityEditor;

using UnityEngine;

namespace ZL.Unity
{
    public static partial class SerializedObjectExtensions
    {
        public static void ScriptField(this SerializedObject instance)
        {
            var enabled_backup = GUI.enabled;

            GUI.enabled = false;

            EditorGUILayout.PropertyField(instance.FindProperty("m_Script"));

            GUI.enabled = enabled_backup;
        }
    }
}