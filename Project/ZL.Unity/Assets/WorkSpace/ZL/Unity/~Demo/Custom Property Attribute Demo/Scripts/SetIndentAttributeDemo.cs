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

        private string test0 = "";

        [Space]

        [Text("[SetIndent(-1)]")]

        [SetIndent(-1)]

        [UsingCustomProperty]

        [SerializeField]

        private string test1 = "";

        [Space]

        [Text("[SetIndent(0)]")]

        [SetIndent(0)]

        [UsingCustomProperty]

        [SerializeField]

        private string test2 = "";

        [Space]

        [Text("[SetIndent(1)]")]

        [SetIndent(1)]

        [UsingCustomProperty]

        [SerializeField]

        private string test3 = "";

        [Line]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest0 = null;

        [Space]

        [Line]

        [Text("[SetIndent(-1)]")]

        [SetIndent(-1)]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest1 = null;

        [Space]

        [Line]

        [Text("[SetIndent(0)]")]

        [SetIndent(0)]

        [UsingCustomProperty]

        [SerializeField]

        private TestClass classTest2 = null;

        [Space]

        [Line]

        [Text("[SetIndent(1)]")]

        [SetIndent(1)]

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
            private string test0 = "";

            [Space]

            [Text("[SetIndent(-1)]")]

            [SetIndent(-1)]

            [UsingCustomProperty]

            [SerializeField]

            private string test1 = "";

            [Space]

            [Text("[SetIndent(0)]")]

            [SetIndent(0)]

            [UsingCustomProperty]

            [SerializeField]

            private string test2 = "";

            [Space]

            [Text("[SetIndent(1)]")]

            [SetIndent(1)]

            [UsingCustomProperty]

            [SerializeField]

            private string test3 = "";
        }
    }
}