using TMPro;

using UnityEngine.UI;

namespace ZL
{
    public static partial class SelectableExtension
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
    }
}