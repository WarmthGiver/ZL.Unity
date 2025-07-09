#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class ToggleAttributeDemo : MonoBehaviour
    {
        [Space]

        private string test0 = "";

        [Space]

        private bool toggle = false;

        [Space]

        [ToggleIf("toggle", true)]

        [Text("[Toggle(\"toggle\", true)]")]

        [UsingCustomProperty]

        [SerializeField]

        private string test1 = "";

        [ToggleIf("toggle", false)]

        [Text("[Toggle(\"toggle\", false)]")]

        [UsingCustomProperty]

        [SerializeField]

        private string test2 = "";

        [Space]

        [ToggleIf("Toggle", false)]

        [Text("[Toggle(\"Toggle\", false)]")]

        [UsingCustomProperty]

        [SerializeField]

        private string test3 = "";
    }
}