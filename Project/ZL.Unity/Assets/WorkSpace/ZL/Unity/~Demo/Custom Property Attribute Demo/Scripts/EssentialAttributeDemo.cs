#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class EssentialAttributeDemo : MonoBehaviour
    {
        [Space]

        [UsingCustomProperty]

        [Text("[Essential]")]

        [Essential]

        public Transform test1;

        [Space]

        [UsingCustomProperty]

        [Text("[Essential]")]

        [Essential]

        public Transform test2;

        [Space]

        [UsingCustomProperty]

        [Text("[Essential]")]

        [Essential]

        public string test3;
    }
}