using UnityEngine;

namespace ZL
{
    public static partial class Vector2Extension
    {
        public static Vector2 Round(this Vector2 instance, int digits)
        {
            instance.x = instance.x.Round(digits);

            instance.y = instance.x.Round(digits);

            return instance;
        }
    }
}