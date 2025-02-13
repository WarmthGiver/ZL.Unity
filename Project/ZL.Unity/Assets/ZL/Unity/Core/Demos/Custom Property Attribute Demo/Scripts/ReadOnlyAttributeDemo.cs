#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class ReadOnlyAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [DrawCustomProperty]

        [Text("[ReadOnly]")]

        [ReadOnly]

        public string test1;



        [Space]

        [DrawCustomProperty]

        [Text("[ReadOnlyInEditMode]")]

        [ReadOnlyInEditMode]

        public string test2;



        [Space]

        [DrawCustomProperty]

        [Text("[ReadOnlyInPlayMode]")]

        [ReadOnlyInPlayMode]

        public string test3;
    }
}