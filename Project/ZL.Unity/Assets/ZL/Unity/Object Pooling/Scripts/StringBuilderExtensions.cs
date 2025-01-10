using System.Text;

namespace ZL.Unity.ObjectPooling
{
    public static partial class StringBuilderExtensions
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