using System;

namespace ZL.CS
{
    public static partial class CharExtensions
    {
        public static char ToUpper(this char instance)
        {
            return char.ToUpper(instance);
        }

        public static char ToLower(this char instance)
        {
            return char.ToLower(instance);
        }

        public static string Append(this char instance, string value)
        {
            int length = value.Length;

            void SpanAction(Span<char> span, string state)
            {
                span[0] = instance;

                for (int i = 0; i < length; ++i)
                {
                    span[i + 1] = state[i];
                }
            }

            return string.Create(1 + length, value, SpanAction);
        }
    }
}