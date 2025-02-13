#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class AliasAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [DrawCustomProperty]

        [Text("[Alias(\"TEST 1\")]")]

        [Alias("TEST 1")]

        public string test1;



        [Space]

        [DrawCustomProperty]

        [Text("[Alias(null)]")]

        [Alias(null)]

        public string test2;



        [Space]

        [DrawCustomProperty]

        [Text("[Alias(\"\")]")]

        [Alias("")]

        public string test3;
    }
}