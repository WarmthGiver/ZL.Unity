using System.Text;

namespace ZL.CS.Pooling
{
    public static partial class PooledStringBuilder
    {
        public static string Concat(params char[] values)
        {
            var stringBuilder = ClassPool<StringBuilder>.Generate();

            var @string = stringBuilder.Concat(values);

            ClassPool<StringBuilder>.Collect(stringBuilder.Clear());

            return @string;
        }

        public static string Concat(params string[] values)
        {
            var stringBuilder = ClassPool<StringBuilder>.Generate();

            var @string = stringBuilder.Concat(values);

            ClassPool<StringBuilder>.Collect(stringBuilder.Clear());

            return @string;
        }
    }
}