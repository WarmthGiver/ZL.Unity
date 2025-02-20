namespace ZL.CS.Unity
{
    public sealed class EnumIntAttribute : EnumValueAttribute
    {
        public readonly int value;

        public EnumIntAttribute(int value)
        {
            this.value = value;
        }
    }
}