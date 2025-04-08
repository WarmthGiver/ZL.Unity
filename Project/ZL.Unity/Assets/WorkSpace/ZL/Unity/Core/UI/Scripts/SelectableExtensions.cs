using TMPro;

using UnityEngine.UI;

namespace ZL.Unity
{
    public static partial class SelectableExtensions
    {
        public static void AddImage(this Selectable instance)
        {
            instance.targetGraphic = instance.AddComponent<Image>();
        }

        public static void AddtText(this Selectable instance)
        {
            instance.targetGraphic = instance.AddComponent<Text>();
        }

        public static void AddTextMeshPro(this Selectable instance)
        {
            instance.targetGraphic = instance.AddComponent<TextMeshProUGUI>();
        }

        public static void CreateImage(this Selectable instance)
        {
            instance.targetGraphic = Creator.CreateGraphic<Image>();
        }

        public static void CreateText(this Selectable instance, string textString)
        {
            instance.targetGraphic = Creator.CreateText(textString);
        }

        public static void CreateTextMeshPro(this Selectable instance, string textString)
        {
            instance.targetGraphic = Creator.CreateTextMeshPro(textString);
        }
    }
}