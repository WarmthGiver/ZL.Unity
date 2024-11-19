using System;

using System.Linq;

using Unity.VisualScripting;

namespace ZL
{
    public static partial class StringExtension
    {
        public static string Concat(params char[] characters)
        {
            int length = characters.Length;

            return string.Create(length, characters, (span, state) =>
            {
                for (int i = 0; i < length; ++i)
                {
                    span[i] = state[i];
                }
            });
        }

        public static bool IsNullOrEmpty(this string instance)
        {
            return string.IsNullOrEmpty(instance);
        }

        public static string RemoveFromFront(this string instance, string toRemove)
        {
            return instance.Remove(instance.IndexOf(toRemove), toRemove.Length);
        }

        public static string RemoveFromBehind(this string instance, string toRemove)
        {
            return instance.Remove(instance.LastIndexOf(toRemove), toRemove.Length);
        }

        public static string ToUpperInitial(this string instance)
        {
            if (instance.Length > 1)
            {
                instance.ToLower();

                return instance[0].ToUpper().Append(instance[1..]);
            }

            return instance[0].ToUpper().ToString();
        }

        public static string ToLowerInitial(this string instance)
        {
            if (instance.Length > 1)
            {
                return instance[0].ToLower().Append(instance[1..]);
            }

            return instance[0].ToLower().ToString();
        }

        public static string Append(this string instance, char value)
        {
            int length = instance.Length;

            return string.Create(length + 1, instance, (span, state) =>
            {
                for (int i = 0; i < length; ++i)
                {
                    span[i] = state[i];
                }

                span[length] = value;
            });
        }

        public static string ToCamelCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Camel, '\0');
        }

        public static string ToPascalCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Title, '\0');
        }

        public static string ToUpperCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Upper, ' ');
        }

        public static string ToTitleCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Title, ' ');
        }

        public static string ToSentenceCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Sentence, ' ');
        }

        public static string ToKebabCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Lower, '-');
        }

        public static string ToUpperKebabCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Upper, '-');
        }

        public static string ToSnakeCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Lower, '_');
        }

        public static string ToUpperSnakeCase(this string instance)
        {
            return instance.ToLetterCase(LetterCaseStyle.Upper, '_');
        }

        public static string ToLetterCase(this string instance, LetterCaseStyle style, char separator)
        {
            switch (style)
            {
                case LetterCaseStyle.Upper:

                    instance = instance.SplitWords(separator);

                    instance = instance.ToUpper();

                    break;

                case LetterCaseStyle.Title:

                    instance = string.Join(separator, instance.SplitWords().Select(word => word.ToUpperInitial()));

                    break;

                case LetterCaseStyle.Sentence:

                    instance = string.Join(separator, instance.SplitWords().Select(word => word.ToLowerInitial()));

                    instance = instance.ToUpperInitial();

                    break;

                case LetterCaseStyle.Camel:

                    instance = string.Join(separator, instance.SplitWords().Select(word => word.ToUpperInitial()));

                    instance = instance.ToLowerInitial();

                    break;

                case LetterCaseStyle.Lower:

                    instance = instance.SplitWords(separator);

                    instance = instance.ToLower();

                    break;
            }

            return instance;
        }

        public static string[] SplitWords(this string instance)
        {
            instance = instance.SplitWords(' ');

            return instance.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}