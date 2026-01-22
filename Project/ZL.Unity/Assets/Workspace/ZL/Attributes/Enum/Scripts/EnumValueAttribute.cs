using System;

using System.Reflection;

namespace ZL.Unity
{
    public abstract class EnumValueAttribute : Attribute
    {
        public static partial class Cache<TEnum, TEnumValueAttribute>

            where TEnum : Enum

            where TEnumValueAttribute : EnumValueAttribute
        {
            public static TEnumValueAttribute Get(TEnum key)
            {
                if (!StaticDictionary<TEnum, TEnumValueAttribute>.Get(key, out var value))
                {
                    var field = key.GetType().GetField(key.ToString());

                    var attribute = field.GetCustomAttribute<TEnumValueAttribute>(false);

                    StaticDictionary<TEnum, TEnumValueAttribute>.Add(key, attribute);
                }

                return value;
            }
        }
    }
}