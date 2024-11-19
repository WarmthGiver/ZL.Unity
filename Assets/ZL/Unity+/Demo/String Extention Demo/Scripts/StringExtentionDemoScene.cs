using System;

using TMPro;

using UnityEngine;

namespace ZL.Demo
{
    using ZL.ObjectPooling;

    [DisallowMultipleComponent]

    [ExecuteInEditMode]

    public sealed class StringExtentionDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextMeshProUGUI text;

        [SerializeField]

        private TMP_InputField inputField;

        private void Awake()
        {
            inputField.onValueChanged.AddListener(Refresh);
        }

        public void Refresh(string text)
        {
            this.text.text = PooledStringBuilder.Concat("<color=#808080>",

                "Camel Case: ", text.ToCamelCase(), Environment.NewLine,
                "Pascal Case: ", text.ToPascalCase(), Environment.NewLine,
                Environment.NewLine,
                "Sentence Case: ", text.ToSentenceCase(), Environment.NewLine,
                "Title Case: ", text.ToTitleCase(), Environment.NewLine,
                "Upper Case: ", text.ToUpperCase(), Environment.NewLine,
                Environment.NewLine,
                "Kebab Case: ", text.ToKebabCase(), Environment.NewLine,
                "Upper Kebab Case: ", text.ToUpperKebabCase(), Environment.NewLine,
                Environment.NewLine,
                "Snake Case: ", text.ToSnakeCase(), Environment.NewLine,
                "Upper Snake Case: ", text.ToUpperSnakeCase(), "</color>");
        }
    }
}