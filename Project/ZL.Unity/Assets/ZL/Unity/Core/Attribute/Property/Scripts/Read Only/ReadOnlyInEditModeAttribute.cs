using UnityEngine;

namespace ZL.Unity
{
    public sealed class ReadOnlyInEditModeAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.IsEnabled = Application.isPlaying;

            return true;
        }

#endif
    }
}