#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class CollectionTest : MonoBehaviour
    {
        [Space]

        [Line]

        [Line]

        [Line]

        public Wrapper<List<TestClass>> textList;

        [Serializable]

        public sealed class TestClass
        {
            [LayerField]

            [Line]

            [Line]

            [Line]

            public int layer;

            [TagField]

            [Line]

            [Line]

            [Line]

            public string tag = "test";
        }
    }
}