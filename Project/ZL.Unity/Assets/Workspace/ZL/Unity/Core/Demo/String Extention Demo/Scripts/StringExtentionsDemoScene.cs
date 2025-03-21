#pragma warning disable

using System;

using System.Text;

using TMPro;

using UnityEngine;

namespace ZL.Unity.StringExtentionsDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    [ExecuteInEditMode]

    public sealed class StringExtentionsDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextMeshProUGUI text;

        [SerializeField]

        private TMP_InputField inputField;

        private readonly StringBuilder stringBuilder = new();

        private void Awake()
        {
            inputField.onValueChanged.AddListener(Refresh);
        }

        public void Refresh(string text)
        {
            this.text.text = stringBuilder.Concat(

                "\n",

                "\n",

                "Camel Case: ", text.ToCamelCase(), "\n",

                "Pascal Case: ", text.ToPascalCase(), "\n",

                "\n",

                "Sentence Case: ", text.ToSentenceCase(), "\n",

                "Title Case: ", text.ToTitleCase(), "\n",

                "Upper Case: ", text.ToUpperCase(), "\n",

                "\n",

                "Kebab Case: ", text.ToKebabCase(), "\n",

                "Upper Kebab Case: ", text.ToUpperKebabCase(), "\n",

                "\n",

                "Snake Case: ", text.ToSnakeCase(), "\n",

                "Upper Snake Case: ", text.ToUpperSnakeCase(), "\n",

                "\n",

                "\n");

            stringBuilder.Clear();
        }
    }
}