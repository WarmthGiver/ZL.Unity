using System.Diagnostics;

using UnityEngine;

namespace ZL.CS.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ReadOnlyWhenEditModeAttribute : CustomPropertyAttribute
    {
#if UNITY_EDITOR

        protected override void Preset(Drawer drawer)
        {
            drawer.IsEnabled = Application.isPlaying;
        }

#endif
    }
}