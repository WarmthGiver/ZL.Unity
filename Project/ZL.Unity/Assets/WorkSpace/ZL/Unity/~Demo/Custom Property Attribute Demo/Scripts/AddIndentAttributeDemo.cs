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

        [SerializeField]

        private string test0 = "";

        [Space]

        [Text("[AddIndent(-1)]")]

        [AddIndent(-1)]

        [UsingCustomProperty]

        [SerializeField]

        private string test1 = "";

        [Space]

        [Text("[AddIndent(0)]")]

        [AddIndent(0)]

        [UsingCustomProperty]

        [SerializeField]

        private string test2 = "";

        [Space]

        [Text("[AddIndent(1)]")]

        [AddIndent(1)]

        [UsingCustomProperty]

        [SerializeField]

        private string test3 = "";

        [Line]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest0 = null;

        [Space]

        [Line]

        [Text("[AddIndent(-1)]")]

        [AddIndent(-1)]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest1 = null;

        [Space]

        [Line]

        [Text("[AddIndent(0)]")]

        [AddIndent(0)]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest2 = null;

        [Space]

        [Line]

        [Text("[AddIndent(1)]")]

        [AddIndent(1)]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest3 = null;

        [Line]

        [UsingCustomProperty]

        [SerializeField]

        private Wrapper<List<TestClass>> collectionTest = null;

        [Serializable]

        private sealed class TestClass
        {
            [SerializeField]

            private string test0 = "";

            [Space]

            [Text("[AddIndent(-1)]")]

            [AddIndent(-1)]

            [UsingCustomProperty]

            [SerializeField]

            private string test1 = "";

            [Space]

            [Text("[AddIndent(0)]")]

            [AddIndent(0)]

            [UsingCustomProperty]

            [SerializeField]

            private string test2 = "";

            [Space]

            [Text("[AddIndent(1)]")]

            [AddIndent(1)]

            [UsingCustomProperty]

            [SerializeField]

            private string test3 = "";
        }
    }
}