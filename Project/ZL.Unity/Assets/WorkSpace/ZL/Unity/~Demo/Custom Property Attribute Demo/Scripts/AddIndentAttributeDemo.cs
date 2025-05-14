#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class AddIndentAttributeDemo : MonoBehaviour
    {
        [Space]

        public string test0 = "";

        [Space]

        [UsingCustomProperty]

        [Text("[AddIndent(-1)]")]

        [AddIndent(-1)]

        public string test1 = "";

        [Space]

        [UsingCustomProperty]

        [Text("[AddIndent(0)]")]

        [AddIndent(0)]

        public string test2 = "";

        [Space]

        [UsingCustomProperty]

        [Text("[AddIndent(1)]")]

        [AddIndent(1)]

        public string test3 = "";

        [UsingCustomProperty]

        [Line]

        public TestClass classTest0 = null;

        [Space]

        [UsingCustomProperty]

        [Line]

        [Text("[AddIndent(-1)]")]

        [AddIndent(-1)]

        public TestClass classTest1 = null;

        [Space]

        [UsingCustomProperty]

        [Line]

        [Text("[AddIndent(0)]")]

        [AddIndent(0)]

        public TestClass classTest2 = null;

        [Space]

        [UsingCustomProperty]

        [Line]

        [Text("[AddIndent(1)]")]

        [AddIndent(1)]

        public TestClass classTest3 = null;

        [UsingCustomProperty]

        [Line]

        public Wrapper<List<TestClass>> collectionTest = null;

        [Serializable]

        public sealed class TestClass
        {
            public string test0 = "";

            [Space]

            [UsingCustomProperty]

            [Text("[AddIndent(-1)]")]

            [AddIndent(-1)]

            public string test1 = "";

            [Space]

            [UsingCustomProperty]

            [Text("[AddIndent(0)]")]

            [AddIndent(0)]

            public string test2 = "";

            [Space]

            [UsingCustomProperty]

            [Text("[AddIndent(1)]")]

            [AddIndent(1)]

            public string test3 = "";
        }
    }
}