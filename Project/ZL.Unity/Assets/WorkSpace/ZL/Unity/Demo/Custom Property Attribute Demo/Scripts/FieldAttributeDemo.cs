#pragma warning disable

using UnityEngine;

namespace ZL.Unity.CustomPropertyAttributeDemo
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

        [Text("[LabelField]")]

        [LabelField]

        public string test2;

        [Space]

        [UsingCustomProperty]

        [Text("[LayerField]")]

        [LayerField]

        public int test3;

        [Space]

        [UsingCustomProperty]

        [Text("[LayerField]")]

        [LayerField]

        public string test4;

        [Space]

        [UsingCustomProperty]

        [Text("[TagField]")]

        [TagField]

        public string test5 = "Untagged";

        [Space]

        [UsingCustomProperty]

        [Text("[TagField]")]

        [TagField]

        public int test6;

        [Space]

        [UsingCustomProperty]

        [Text("[EmptyField]")]

        [EmptyField]

        public string test7;
    }
}