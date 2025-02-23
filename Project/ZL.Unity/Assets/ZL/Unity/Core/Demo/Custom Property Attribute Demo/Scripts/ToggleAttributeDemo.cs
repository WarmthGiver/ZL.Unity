#pragma warning disable

using UnityEngine;

namespace ZL.Unity.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class ToggleAttributeDemo : MonoBehaviour
    {
        public string test0;

        [Space]

        public bool toggle;

        [Space]

        [UsingCustomProperty]

        [ToggleIf("toggle", true)]

        [Text("[Toggle(\"toggle\", true)]")]

        public string test1;

        [UsingCustomProperty]

        [ToggleIf("toggle", false)]

        [Text("[Toggle(\"toggle\", false)]")]

        public string test2;

        [Space]

        [UsingCustomProperty]

        [ToggleIf("Toggle", false)]

        [Text("[Toggle(\"Toggle\", false)]")]

        public string test3;
    }
}