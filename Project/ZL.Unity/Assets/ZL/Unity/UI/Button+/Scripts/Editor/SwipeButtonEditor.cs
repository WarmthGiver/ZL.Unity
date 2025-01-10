using UnityEditor;

using UnityEngine;

namespace ZL.Unity.UI.Editor
{
    [CustomEditor(typeof(SwipeButton))]

    public sealed class SwipeButtonEditor : AutoButtonEditor
    {
        private SwipeButton swipeButton;

        private SerializedProperty swipeMagnitude;

        private SerializedProperty swipeMagnitude_Required;

        private SerializedProperty onSwipeUp;

        private SerializedProperty onSwipeDown;

        private SerializedProperty onSwipeRight;

        private SerializedProperty onSwipeLeft;

        protected override void OnEnable()
        {
            base.OnEnable();

            swipeButton = target as SwipeButton;

            swipeMagnitude = serializedObject.FindProperty("swipeMagnitude");

            swipeMagnitude_Required = serializedObject.FindProperty("swipeMagnitude_Required");

            onSwipeUp = serializedObject.FindProperty("onSwipeUp");

            onSwipeDown = serializedObject.FindProperty("onSwipeDown");

            onSwipeRight = serializedObject.FindProperty("onSwipeRight");

            onSwipeLeft = serializedObject.FindProperty("onSwipeLeft");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            base.OnInspectorGUI();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Swipe");

            ++EditorGUI.indentLevel;

            EditorGUILayout.PropertyField(swipeMagnitude, new GUIContent("Magnitude"));

            EditorGUILayout.PropertyField(swipeMagnitude_Required, new GUIContent("Required"));

            --EditorGUI.indentLevel;

            EditorGUILayout.Space();

            if (GUILayout.Button("Invoke"))
            {
                swipeButton.OnSwipeUp.Invoke();
            }

            EditorGUILayout.PropertyField(onSwipeUp);

            EditorGUILayout.Space();

            if (GUILayout.Button("Invoke"))
            {
                swipeButton.OnSwipeDown.Invoke();
            }

            EditorGUILayout.PropertyField(onSwipeDown);

            EditorGUILayout.Space();

            if (GUILayout.Button("Invoke"))
            {
                swipeButton.OnSwipeRight.Invoke();
            }

            EditorGUILayout.PropertyField(onSwipeRight);

            EditorGUILayout.Space();

            if (GUILayout.Button("Invoke"))
            {
                swipeButton.OnSwipeLeft.Invoke();
            }

            EditorGUILayout.PropertyField(onSwipeLeft);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
