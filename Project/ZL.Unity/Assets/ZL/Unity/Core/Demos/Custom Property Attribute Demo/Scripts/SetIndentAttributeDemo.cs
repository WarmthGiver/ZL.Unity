#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class SetIndentAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [DrawCustomProperty]

        [Text("[SetIndent(-1)]")]

        [SetIndent(-1)]

        public string test1;



        [Space]

        [DrawCustomProperty]

        [Text("[SetIndent(0)]")]

        [SetIndent(0)]

        public string test2;



        [Space]

        [DrawCustomProperty]

        [Text("[SetIndent(1)]")]

        [SetIndent(1)]

        public string test3;



        [DrawCustomProperty]

        [Line]

        public TestClass classTest0;



        [Space]

        [DrawCustomProperty]

        [Line]

        [Text("[SetIndent(-1)]")]

        [SetIndent(-1)]

        public TestClass classTest1;



        [Space]

        [DrawCustomProperty]

        [Line]

        [Text("[SetIndent(0)]")]

        [SetIndent(0)]

        public TestClass classTest2;



        [Space]

        [DrawCustomProperty]

        [Line]

        [Text("[SetIndent(1)]")]

        [SetIndent(1)]

        public TestClass classTest3;



        [DrawCustomProperty]

        [Line]

        public Wrapper<List<TestClass>> collectionTest;



        [Serializable]

        public sealed class TestClass
        {
            public string test0;



            [Space]

            [DrawCustomProperty]

            [Text("[SetIndent(-1)]")]

            [SetIndent(-1)]

            public string test1;



            [Space]

            [DrawCustomProperty]

            [Text("[SetIndent(0)]")]

            [SetIndent(0)]

            public string test2;



            [Space]

            [DrawCustomProperty]

            [Text("[SetIndent(1)]")]

            [SetIndent(1)]

            public string test3;
        }
    }
}