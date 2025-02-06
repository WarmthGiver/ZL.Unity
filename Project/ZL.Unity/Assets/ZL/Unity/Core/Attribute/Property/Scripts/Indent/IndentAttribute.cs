using System.Diagnostics;

namespace ZL.Unity
{
    [Conditional("UNITY_EDITOR")]

    public class IndentAttribute : UnitedPropertyAttribute
    {
        protected readonly int level;

        public IndentAttribute(int level)
        {
            this.level = level;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.IndentLevel = level;

            return true;
        }

#endif
    }
}