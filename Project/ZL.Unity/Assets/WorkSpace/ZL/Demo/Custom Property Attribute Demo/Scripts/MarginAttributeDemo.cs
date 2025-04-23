#pragma warning disable

using UnityEngine;

namespace ZL.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class MarginAttributeDemo : MonoBehaviour
    {
        [Space]

        public string test0;

        [UsingCustomProperty]

        [Margin]

        [Text("[Margin]")]

        public string test1;

        [UsingCustomProperty]

        [Margin(30)]

        [Text("[Margin(30)]")]

        public int test2;

        [UsingCustomProperty]

        [Margin(50)]

        [Text("[Margin(50)]")]

        public string test3;
    }
}