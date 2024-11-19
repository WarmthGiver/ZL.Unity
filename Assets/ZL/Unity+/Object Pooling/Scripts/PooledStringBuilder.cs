using System.Linq;

namespace ZL.ObjectPooling
{
    public static class PooledStringBuilder
    {
        public static string Concat(params char[] values)
        {
            var stringBuilder = StringBuilderPool.Clone(values.Length);

            foreach (var value in values)
            {
                stringBuilder.Append(value);
            }

            return stringBuilder.Release();
        }

        public static string Concat(params string[] values)
        {
            var stringBuilder = StringBuilderPool.Clone(values.Sum(value => value.Length));

            foreach (var value in values)
            {
                stringBuilder.Append(value);
            }

            return stringBuilder.Release();
        }
    }
}