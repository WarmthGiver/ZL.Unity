using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public sealed class MarginAttribute : CustomPropertyAttribute
    {
        private readonly float height;

        public MarginAttribute(float height = defaultSpaceHeight)
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