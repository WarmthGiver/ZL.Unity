using System;

using UnityEngine;

public static class TypeExtensions
{
    public static bool Belong(this Type instance, params Type[] types)
    {
        foreach (var type in types)
        {
            if (instance == type)
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsInheritGeneric(this Type instance, out Type result)
    {
        Type type = typeof(Component);

        while (instance != type)
        {
            if (instance.IsGenericType == true)
            {
                result = instance;

                return true;
            }

            instance = instance.BaseType;
        }

        result = null;

        return false;
    }
}