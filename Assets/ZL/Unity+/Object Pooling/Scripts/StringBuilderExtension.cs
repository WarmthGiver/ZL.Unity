using System.Text;

namespace ZL.ObjectPooling
{
    public static partial class StringBuilderExtension
    {
        public static string Release(this StringBuilder instance)
        {
            var @string = instance.ToString();

            instance.Clear();

            ClassPool<StringBuilder>.Collect(instance);

            return @string;
        }
    }
}