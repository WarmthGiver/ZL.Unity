#pragma warning disable

using UnityEngine;

namespace ZL.CS.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class AliasAttributeDemo : MonoBehaviour
    {
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
    }
}