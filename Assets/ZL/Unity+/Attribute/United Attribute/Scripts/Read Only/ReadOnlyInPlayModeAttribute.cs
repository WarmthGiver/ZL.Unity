using UnityEngine;

namespace ZL
{
    public sealed class ReadOnlyInPlayModeAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.IsEnabled = !Application.isPlaying;

            return true;
        }

#endif
    }
}