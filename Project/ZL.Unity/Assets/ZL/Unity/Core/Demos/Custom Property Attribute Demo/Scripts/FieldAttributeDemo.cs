#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class FieldAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [DrawCustomProperty]

        [Text("[PropertyField]")]

        [PropertyField]

        public string test1;



        [Space]

        [DrawCustomProperty]

        [Text("[LayerField]")]

        [LayerField]

        public int test2;



        [Space]

        [DrawCustomProperty]

        [Text("[LayerField]")]

        [LayerField]

        public string test3;



        [Space]

        [DrawCustomProperty]

        [Text("[TagField]")]

        [TagField]

        public string test4 = "Untagged";



        [Space]

        [DrawCustomProperty]

        [Text("[TagField]")]

        [TagField]

        public int test5;



        [Space]

        [DrawCustomProperty]

        [Text("[EmptyField]")]

        [EmptyField]

        public string test6;
    }
}