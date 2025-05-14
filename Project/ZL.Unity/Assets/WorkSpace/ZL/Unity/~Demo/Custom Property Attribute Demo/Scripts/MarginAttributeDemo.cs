#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class MarginAttributeDemo : MonoBehaviour
    {
        [Space]

        public string test0 = "";

        [UsingCustomProperty]

        [Margin]

        [Text("[Margin]")]

        public string test1 = "";

        [UsingCustomProperty]

        [Margin(30)]

        [Text("[Margin(30)]")]

        public int test2 = 0;

        [UsingCustomProperty]

        [Margin(50)]

        [Text("[Margin(50)]")]

        public string test3 = "";
    }
}