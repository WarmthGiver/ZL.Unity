#pragma warning disable

using UnityEngine;

namespace ZL.CS.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class FieldAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [UsingCustomProperty]

        [Text("[PropertyField]")]

        [PropertyField]

        public string test1;



        [Space]

        [UsingCustomProperty]

        [Text("[LayerField]")]

        [LayerField]

        public int test2;



        [Space]

        [UsingCustomProperty]

        [Text("[LayerField]")]

        [LayerField]

        public string test3;



        [Space]

        [UsingCustomProperty]

        [Text("[TagField]")]

        [TagField]

        public string test4 = "Untagged";



        [Space]

        [UsingCustomProperty]

        [Text("[TagField]")]

        [TagField]

        public int test5;



        [Space]

        [UsingCustomProperty]

        [Text("[EmptyField]")]

        [EmptyField]

        public string test6;
    }
}