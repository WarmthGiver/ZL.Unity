#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class EssentialAttributeDemo : MonoBehaviour
    {
        [Space]

        [DrawCustomProperty]

        [Text("[Essential]")]

        [Essential]

        public Transform test1;



        [Space]

        [DrawCustomProperty]

        [Text("[Essential]")]

        [Essential]

        public Transform test2;



        [Space]

        [DrawCustomProperty]

        [Text("[Essential]")]

        [Essential]

        public string test3;
    }
}