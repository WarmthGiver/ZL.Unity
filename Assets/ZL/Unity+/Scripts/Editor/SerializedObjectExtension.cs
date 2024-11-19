using UnityEditor;

using UnityEngine;

namespace ZL
{
    public static partial class SerializedObjectExtension
    {
        public static void ScriptField(this SerializedObject @this)
        {
            var enabled_backup = GUI.enabled;

            GUI.enabled = false;

            EditorGUILayout.PropertyField(@this.FindProperty("m_Script"));

            GUI.enabled = enabled_backup;
        }
    }
}