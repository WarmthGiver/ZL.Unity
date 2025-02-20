using System.Diagnostics;

namespace ZL.CS.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class MarginAttribute : CustomPropertyAttribute
    {
        private readonly float height;

        public MarginAttribute()
        {
            height = defaultSpaceHeight;
        }

        public MarginAttribute(float height)
        {
            this.height = height;
        }

#if UNITY_EDITOR

        protected override void Draw(Drawer drawer)
        {
            drawer.Margin(height);
        }

#endif
    }
}