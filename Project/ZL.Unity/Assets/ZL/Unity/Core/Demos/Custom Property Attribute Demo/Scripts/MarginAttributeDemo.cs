#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class MarginAttributeDemo : MonoBehaviour
    {
        public string test0;



        [DrawCustomProperty]

        [Margin]

        [Text("[Margin]")]

        public string test1;



        [DrawCustomProperty]

        [Margin(30)]

        [Text("[Margin(30)]")]

        public int test2;



        [DrawCustomProperty]

        [Margin(50)]

        [Text("[Margin(50)]")]

        public string test3;
    }
}