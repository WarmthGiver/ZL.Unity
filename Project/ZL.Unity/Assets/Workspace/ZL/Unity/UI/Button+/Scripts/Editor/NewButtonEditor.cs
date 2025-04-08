using UnityEditor;

using UnityEditor.UI;

using UnityEngine;

namespace ZL.Unity.UI
{
    [CustomEditor(typeof(NewButton))]

    public class NewButtonEditor : SelectableEditor
    {
        private NewButton instance;

        private SerializedProperty onClick;

        protected override void OnEnable()
        {
            base.OnEnable();

            instance = (NewButton)target;

            onClick = serializedObject.FindProperty("m_OnClick");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            serializedObject.ScriptField();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Create Image"))
            {
                instance.CreateImage();
            }

            if (GUILayout.Button("Create Text"))
            {
                instance.CreateText("Button");
            }

            if (GUILayout.Button("Create Text (TMP)"))
            {
                instance.CreateTextMeshPro("Button");
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button("Invoke"))
            {
                instance.onClick.Invoke();
            }

            EditorGUILayout.PropertyField(onClick);

            serializedObject.ApplyModifiedProperties();
        }
    }
}