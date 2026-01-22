using System.Collections.Generic;

public static class ListEx
{
    public static IEnumerator<T> GetEnumerator<T>(this IList<T> list, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            yield return list[i];
        }
    }
}