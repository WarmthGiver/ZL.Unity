using TMPro;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    public static partial class SelectableEx
    {
        public static void AddImage(this Selectable instance)
        {
            instance.targetGraphic = instance.gameObject.AddComponent<Image>();
        }

        public static void AddtText(this Selectable instance)
        {
            instance.targetGraphic = instance.gameObject.AddComponent<Text>();
        }

        public static void AddTextMeshPro(this Selectable instance)
        {
            instance.targetGraphic = instance.gameObject.AddComponent<TextMeshProUGUI>();
        }

        public static void CreateImage(this Selectable instance)
        {
            instance.targetGraphic = UICreator.CreateGraphic<Image>();
        }

        public static void CreateText(this Selectable instance, string textString)
        {
            instance.targetGraphic = UICreator.CreateText(textString);
        }

        public static void CreateTextMeshPro(this Selectable instance, string textString)
        {
            instance.targetGraphic = UICreator.CreateTextMeshPro(textString);
        }
    }
}