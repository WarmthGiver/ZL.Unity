#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class SetIndentAttributeDemo : MonoBehaviour
    {
        [Space]

        public string test0;

        [Space]

        [UsingCustomProperty]

        [Text("[SetIndent(-1)]")]

        [SetIndent(-1)]

        public string test1;

        [Space]

        [UsingCustomProperty]

        [Text("[SetIndent(0)]")]

        [SetIndent(0)]

        public string test2;

        [Space]

        [UsingCustomProperty]

        [Text("[SetIndent(1)]")]

        [SetIndent(1)]

        public string test3;

        [UsingCustomProperty]

        [Line]

        public TestClass classTest0;

        [Space]

        [UsingCustomProperty]

        [Line]

        [Text("[SetIndent(-1)]")]

        [SetIndent(-1)]

        public TestClass classTest1;

        [Space]

        [UsingCustomProperty]

        [Line]

        [Text("[SetIndent(0)]")]

        [SetIndent(0)]

        public TestClass classTest2;

        [Space]

        [UsingCustomProperty]

        [Line]

        [Text("[SetIndent(1)]")]

        [SetIndent(1)]

        public TestClass classTest3;

        [UsingCustomProperty]

        [Line]

        public Wrapper<List<TestClass>> collectionTest;

        [Serializable]

        public sealed class TestClass
        {
            public string test0;

            [Space]

            [UsingCustomProperty]

            [Text("[SetIndent(-1)]")]

            [SetIndent(-1)]

            public string test1;

            [Space]

            [UsingCustomProperty]

            [Text("[SetIndent(0)]")]

            [SetIndent(0)]

            public string test2;

            [Space]

            [UsingCustomProperty]

            [Text("[SetIndent(1)]")]

            [SetIndent(1)]

            public string test3;
        }
    }
}