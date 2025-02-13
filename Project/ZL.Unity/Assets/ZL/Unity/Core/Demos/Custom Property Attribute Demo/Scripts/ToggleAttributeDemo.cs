#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class ToggleAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        public bool toggle;



        [Space]

        [DrawCustomProperty]

        [Toggle("toggle", true)]

        [Text("[Toggle(\"toggle\", true)]")]

        public string test1;



        [DrawCustomProperty]

        [Toggle("toggle", false)]

        [Text("[Toggle(\"toggle\", false)]")]

        public string test2;
    }
}