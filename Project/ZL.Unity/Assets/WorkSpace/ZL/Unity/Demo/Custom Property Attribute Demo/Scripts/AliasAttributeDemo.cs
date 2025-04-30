#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class AliasAttributeDemo : MonoBehaviour
    {
        [Space]

        public string test0;

        [Space]

        [UsingCustomProperty]

        [Text("[Alias(\"TEST 1\")]")]

        [Alias("TEST 1")]

        public string test1;

        [Space]

        [UsingCustomProperty]

        [Text("[Alias(null)]")]

        [Alias(null)]

        public string test2;

        [Space]

        [UsingCustomProperty]

        [Text("[Alias(\"\")]")]

        [Alias("")]

        public string test3;

        [Space]

        [UsingCustomProperty]

        [Text("[LabelField]")]

        [Text("[Alias(\"\")]")]

        [LabelField]

        [Alias("")]

        [PropertyField]

        public string test4;
    }
}