#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class MarginAttributeDemo : MonoBehaviour
    {
        [Space]

        private string test0 = "";

        [Margin]

        [Text("[Margin]")]

        [UsingCustomProperty]

        [SerializeField]

        private string test1 = "";

        [Margin(30)]

        [Text("[Margin(30)]")]

        [UsingCustomProperty]

        [SerializeField]

        private int test2 = 0;

        [Margin(50)]

        [Text("[Margin(50)]")]

        [UsingCustomProperty]

        [SerializeField]

        private string test3 = "";
    }
}