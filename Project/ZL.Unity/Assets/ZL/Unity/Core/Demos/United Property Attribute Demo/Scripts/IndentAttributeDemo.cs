#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class IndentAttributeDemo : MonoBehaviour
    {
        [Space]

        [Indent(-1)]

        [Comment("[Indent(-1)]")]

        [Label("Indent -1")]

        [DrawFieldAttribute]

        public string indentMinus1;



        [Space]

        [Indent(0)]

        [Comment("[Indent(0)]")]

        [Label("Indent  0")]

        [DrawFieldAttribute]

        public string indent0;



        [Space]

        [Indent(1)]

        [Comment("[Indent(1)]")]

        [Label("Indent  +1")]

        [DrawFieldAttribute]

        public string indentPlus1;



        [Space]

        public TextClass inClass;

        [Serializable]

        public sealed class TextClass
        {
            [Indent(-1)]

            [Comment("[Indent(-1)]")]

            [Label("Indent -1")]

            [DrawFieldAttribute]

            public string indentMinus1;



            [Space]

            [Indent(0)]

            [Comment("[Indent(0)]")]

            [Label("Indent  0")]

            [DrawFieldAttribute]

            public string indent0;



            [Space]

            [Indent(1)]

            [Comment("[Indent(1)]")]

            [Label("Indent  +1")]

            [DrawFieldAttribute]

            public string indentPlus1;
        }
    }
}