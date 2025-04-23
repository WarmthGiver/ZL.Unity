using System;

namespace ZL
{
    public struct EnumUnion<TEnum>

        where TEnum : Enum
    {
        public TEnum enumValue;

        public int intValue;
    }
}