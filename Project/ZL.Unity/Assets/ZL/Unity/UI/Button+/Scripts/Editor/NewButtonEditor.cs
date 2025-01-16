using UnityEditor;

using UnityEditor.UI;

using UnityEngine;

using ZL.Unity.Tools;

namespace ZL.Unity.UI
{
    [CustomEditor(typeof(NewButton))]

    public class NewButtonEditor : SelectableEditor
    {
        private NewButton newButton;

        private SerializedProperty onClick;

        protected override void OnEnable()
        {
            base.OnEnable();

            newButton = (NewButton)target;

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
                newButton.CreateImage();
            }

            if (GUILayout.Button("Create Text"))
            {
                newButton.CreateText("Button");
            }

            if (GUILayout.Button("Create Text (TMP)"))
            {
                newButton.CreateTextMeshPro("Button");
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            EditorGUILayout.Space();

            if (GUILayout.Button("Invoke"))
            {
                newButton.onClick.Invoke();
            }

            EditorGUILayout.PropertyField(onClick);

            serializedObject.ApplyModifiedProperties();
        }
    }
}