using UnityEngine;

using UnityEngine.UI;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/Button(New)")]
    
    [RequireComponent(typeof(RectTransform))]

    public class NewButton : Button
    {
#pragma warning disable CS0114

        protected virtual void Reset()
        {
            ColorBlock defaultColors = new()
            {
                normalColor = Color.white,

                highlightedColor = new(0.875f, 0.875f, 0.875f, 1f),

                pressedColor = new(0.75f, 0.75f, 0.75f, 1f),

                selectedColor = new(0.875f, 0.875f, 0.875f, 1f),

                disabledColor = new(0.75f, 0.75f, 0.75f, 1f),

                colorMultiplier = 1f,

                fadeDuration = 0.1f,
            };

            colors = defaultColors;

            Navigation navigation = new()
            {
                mode = Navigation.Mode.None,
            };

            this.navigation = navigation;
        }

#pragma warning restore CS0114
    }
}