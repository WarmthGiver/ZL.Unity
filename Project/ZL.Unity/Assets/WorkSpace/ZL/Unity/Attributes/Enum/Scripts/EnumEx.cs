﻿using System;

using UnityEngine;

namespace ZL.Unity
{
    public static partial class EnumEx
    {
        public static bool GetBool<TEnum>(this TEnum instance)

            where TEnum : Enum
        {
            return EnumValueAttribute.Cache<TEnum, EnumBoolAttribute>.Get(instance).value;
        }

        public static float GetFloat<TEnum>(this TEnum instance)

            where TEnum : Enum
        {
            return EnumValueAttribute.Cache<TEnum, EnumFloatAttribute>.Get(instance).value;
        }

        public static int GetInt<TEnum>(this TEnum instance)

            where TEnum : Enum
        {
            return EnumValueAttribute.Cache<TEnum, EnumIntAttribute>.Get(instance).value;
        }

        public static string GetString<TEnum>(this TEnum instance)

            where TEnum : Enum
        {
            return EnumValueAttribute.Cache<TEnum, EnumStringAttribute>.Get(instance).value;
        }

        public static Color GetColor<TEnum>(this TEnum instance)

            where TEnum : Enum
        {
            return EnumValueAttribute.Cache<TEnum, EnumColorAttribute>.Get(instance).value;
        }
    }
}