using System.Diagnostics;

using UnityEngine;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class ReadOnlyInPlayModeAttribute : CustomPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.IsEnabled = !Application.isPlaying;

            return true;
        }

#endif
    }
}