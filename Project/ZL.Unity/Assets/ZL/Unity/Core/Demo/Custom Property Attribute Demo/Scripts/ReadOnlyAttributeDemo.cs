#pragma warning disable

using UnityEngine;

namespace ZL.Unity.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class ReadOnlyAttributeDemo : MonoBehaviour
    {
        public string test0;

        [Space]

        [UsingCustomProperty]

        [Text("[ReadOnly(true)]")]

        [ReadOnly(true)]

        public string test1;

        [Space]

        public bool isReadOnly;

        [Space]

        [UsingCustomProperty]

        [Text("[ReadOnlyWhen(true)]")]

        [ReadOnlyWhen("isReadOnly", true)]

        public string test2;

        [Space]

        [UsingCustomProperty]

        [Text("[ReadOnlyInEditMode]")]

        [ReadOnlyWhenEditMode]

        public string test3;

        [Space]

        [UsingCustomProperty]

        [Text("[ReadOnlyInPlayMode]")]

        [ReadOnlyWhenPlayMode]

        public string test4;
    }
}