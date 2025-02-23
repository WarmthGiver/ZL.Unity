using UnityEditor;

using UnityEngine;

namespace ZL.Unity.UI
{
    [CustomEditor(typeof(AutoButton))]

    public class AutoButtonEditor : NewButtonEditor
    {
        private AutoButton autoButton;

        private SerializedProperty clickDelay;

        private SerializedProperty useCurve;

        private SerializedProperty clickCoolTime;

        private SerializedProperty clickCoolTimeCurve;

        protected override void OnEnable()
        {
            base.OnEnable();

            autoButton = (AutoButton)target;

            clickDelay = serializedObject.FindProperty("clickDelay");

            useCurve = serializedObject.FindProperty("useCurve");

            clickCoolTime = serializedObject.FindProperty("clickCoolTime");

            clickCoolTimeCurve = serializedObject.FindProperty("clickCoolTimeCurve");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            base.OnInspectorGUI();

            EditorGUILayout.LabelField("Auto Click");

            ++EditorGUI.indentLevel;

            EditorGUILayout.PropertyField(clickDelay, new GUIContent("Delay"));

            EditorGUILayout.LabelField("Cool-Time");

            ++EditorGUI.indentLevel;

            EditorGUILayout.PropertyField(useCurve, new GUIContent("Use Curve"));

            if (autoButton.UseCurve)
            {
                EditorGUILayout.PropertyField(clickCoolTimeCurve, new GUIContent());
            }

            else
            {
                EditorGUILayout.PropertyField(clickCoolTime, new GUIContent());
            }

            EditorGUI.indentLevel -= 2;

            serializedObject.ApplyModifiedProperties();
        }
    }
}