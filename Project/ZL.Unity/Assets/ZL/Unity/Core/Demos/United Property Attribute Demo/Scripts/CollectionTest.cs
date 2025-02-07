#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class CollectionTest : MonoBehaviour
    {
        [Space]

        [Line(3f)]

        [DrawFieldAttribute]

        public Wrapper<List<TestClass>> textList;

        [Serializable]

        public sealed class TestClass
        {
            [LayerField]

            [Line(1f, "#00FF00")]

            [DrawFieldAttribute]

            public int layer;

            [TagField]

            [Line(1f, "#0000FF")]

            [DrawFieldAttribute]

            public string tag = "test";
        }
    }
}