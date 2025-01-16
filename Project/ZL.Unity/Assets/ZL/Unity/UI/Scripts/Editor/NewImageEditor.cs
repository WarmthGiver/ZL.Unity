using UnityEditor;

using UnityEditor.UI;

using UnityEngine;

namespace ZL.Unity.UI
{
    [CustomEditor(typeof(NewImage))]

    public sealed class NewImageEditor : ImageEditor
    {
        private NewImage imagePlus;

        private SerializedProperty fitParentSizeTarget;

        protected override void OnEnable()
        {
            base.OnEnable();

            imagePlus = target as NewImage;

            fitParentSizeTarget = serializedObject.FindProperty("fitParentSizeTarget");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            serializedObject.ScriptField();

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            if (EditorGUILayout.BeginFadeGroup(m_ShowNativeSize.faded))
            {
                EditorGUILayout.LabelField("Fit Parent Size");

                ++EditorGUI.indentLevel;

                EditorGUILayout.PropertyField(fitParentSizeTarget, new GUIContent("Target Parent"));

                EditorGUILayout.BeginHorizontal();

                GUILayout.Space(EditorGUIUtility.labelWidth);

                if (GUILayout.Button(new GUIContent("Min", "")))
                {
                    Undo.RecordObject(imagePlus.rectTransform, "Fit Parent Size Min");

                    imagePlus.FitParentSizeMin();

                    UnityEditor.EditorUtility.SetDirty(imagePlus);
                }

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();

                GUILayout.Space(EditorGUIUtility.labelWidth);

                if (GUILayout.Button(new GUIContent("Max", "")))
                {
                    Undo.RecordObject(imagePlus.rectTransform, "Fit Parent Size Max");

                    imagePlus.FitParentSizeMax();

                    UnityEditor.EditorUtility.SetDirty(imagePlus);
                }

                EditorGUILayout.EndHorizontal();

                --EditorGUI.indentLevel;
            }

            EditorGUILayout.EndFadeGroup();

            serializedObject.ApplyModifiedProperties();
        }
    }
}