#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class GetComponenetAttributeDemo : MonoBehaviour
    {
        [Space]

        [UsingCustomProperty]

        [Text("[GetComponent]")]

        [GetComponent]

        public Transform test1 = null;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInParent]")]

        [GetComponentInParent]

        public Transform test2 = null;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInParentOnly]")]

        [GetComponentInParentOnly]

        public Transform test3 = null;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInChildren]")]

        [GetComponentInChildren]

        public Transform test4 = null;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInChildrenOnly]")]

        [GetComponentInChildrenOnly]

        public Transform test5 = null;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponent]")]

        [GetComponent]

        public string test6 = "";
    }
}