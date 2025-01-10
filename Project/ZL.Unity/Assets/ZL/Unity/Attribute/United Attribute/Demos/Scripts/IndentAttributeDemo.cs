#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    [DisallowMultipleComponent]

    public sealed class IndentAttributeDemo : MonoBehaviour
    {
        [Space]

        [Indent(-1), Label("Indent -1")]

        public string indentMinus1;

        [Indent(0), Label("Indent  0")]

        public string indent0;

        [Indent(1), Label("Indent  +1")]

        public string indentPlus1;

        [Space]

        public Class inClass;

        [Serializable]

        public sealed class Class
        {
            [Indent(-1), Label("Indent -1")]

            public string indentMinus1;

            [Indent(0), Label("Indent  0")]

            public string indent0;

            [Indent(1), Label("Indent  +1")]

            public string indentPlus1;
        }
    }
}