#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class ReadOnlyAttributeDemo : MonoBehaviour
    {
        [Space]

        private string test0 = "";

        [Space]

        [Text("[ReadOnly(true)]")]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private string test1 = "";

        [Space]

        private bool isReadOnly = false;

        [Space]

        [Text("[ReadOnlyWhen(true)]")]

        [ReadOnlyIf("isReadOnly", true)]

        [UsingCustomProperty]

        [SerializeField]

        private string test2 = "";

        [Space]

        [Text("[ReadOnlyInEditMode]")]

        [ReadOnlyWhenEditMode]

        [UsingCustomProperty]

        [SerializeField]

        private string test3 = "";

        [Space]

        [Text("[ReadOnlyInPlayMode]")]

        [ReadOnlyWhenPlayMode]

        [UsingCustomProperty]

        [SerializeField]

        private string test4 = "";
    }
}