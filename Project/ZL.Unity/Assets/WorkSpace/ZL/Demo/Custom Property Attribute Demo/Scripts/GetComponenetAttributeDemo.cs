#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class GetComponenetAttributeDemo : MonoBehaviour
    {
        [Space]

        [UsingCustomProperty]

        [Text("[GetComponent]")]

        [GetComponent]

        public Transform test1;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInParent]")]

        [GetComponentInParent]

        public Transform test2;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInParentOnly]")]

        [GetComponentInParentOnly]

        public Transform test3;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInChildren]")]

        [GetComponentInChildren]

        public Transform test4;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponentInChildrenOnly]")]

        [GetComponentInChildrenOnly]

        public Transform test5;

        [Space]

        [UsingCustomProperty]

        [Text("[GetComponent]")]

        [GetComponent]

        public string test6;
    }
}