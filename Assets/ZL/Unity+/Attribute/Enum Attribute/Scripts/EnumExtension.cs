using System;

namespace ZL
{
    public static partial class EnumExtension
    {
        public static bool GetBool<T>(this T instance)

            where T : Enum
        {
            return EnumValueAttribute.Cache<T, EnumBoolAttribute>.Get(instance).value;
        }

        public static float GetFloat<T>(this T instance)

            where T : Enum
        {
            return EnumValueAttribute.Cache<T, EnumFloatAttribute>.Get(instance).value;
        }

        public static int GetInt<T>(this T instance)

            where T : Enum
        {
            return EnumValueAttribute.Cache<T, EnumIntAttribute>.Get(instance).value;
        }

        public static string GetString<T>(this T instance)

            where T : Enum
        {
            return EnumValueAttribute.Cache<T, EnumStringAttribute>.Get(instance).value;
        }
    }
}