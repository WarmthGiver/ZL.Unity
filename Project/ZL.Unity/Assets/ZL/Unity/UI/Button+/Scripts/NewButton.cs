using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
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

                highlightedColor = Color.white,

                pressedColor = new(0.75f, 0.75f, 0.75f, 1f),

                selectedColor = Color.white,

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