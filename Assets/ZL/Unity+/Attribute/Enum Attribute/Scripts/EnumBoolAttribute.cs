namespace ZL
{
    public sealed class EnumBoolAttribute : EnumValueAttribute
    {
        public readonly bool value;

        public EnumBoolAttribute(bool value)
        {
            this.value = value;
        }
    }
}