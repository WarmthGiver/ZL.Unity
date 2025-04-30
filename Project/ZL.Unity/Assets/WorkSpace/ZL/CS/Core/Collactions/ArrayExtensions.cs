using System.Collections.Generic;

namespace ZL.CS.Collections
{
    public static class ArrayExtensions
    {
        public static LinkedList<T> ToLinkedList<T>(this T[] instance)
        {
            LinkedList<T> linkedList = new();

            CopyTo(instance, ref linkedList);

            return linkedList;
        }

        public static void CopyTo<T>(this T[] instance, ref LinkedList<T> linkedList)
        {
            foreach (var item in instance)
            {
                linkedList.AddLast(item);
            }
        }
    }
}