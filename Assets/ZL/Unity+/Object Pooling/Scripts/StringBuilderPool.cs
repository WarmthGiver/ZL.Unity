using System.Text;

namespace ZL.ObjectPooling
{
    public static class StringBuilderPool
    {
        public static StringBuilder Clone(int capacity = 0)
        {
            var stringBuilder = ClassPool<StringBuilder>.Clone();

            stringBuilder.Capacity = capacity;

            return stringBuilder;
        }
    }
}