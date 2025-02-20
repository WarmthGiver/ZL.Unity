#pragma warning disable

using UnityEngine;

namespace ZL.CS.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class ToggleAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        public bool toggle;



        [Space]

        [UsingCustomProperty]

        [ToggleWhen("toggle", true)]

        [Text("[Toggle(\"toggle\", true)]")]

        public string test1;



        [UsingCustomProperty]

        [ToggleWhen("toggle", false)]

        [Text("[Toggle(\"toggle\", false)]")]

        public string test2;
    }
}