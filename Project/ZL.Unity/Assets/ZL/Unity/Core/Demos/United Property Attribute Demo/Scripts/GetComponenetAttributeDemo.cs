#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class GetComponenetAttributeDemo : MonoBehaviour
    {
        [Space]

        [Comment("[GetComponent]")]

        [GetComponent]

        [DrawFieldAttribute]

        public Transform test1;

        [Space]

        [Comment("[GetComponentInParent]")]

        [GetComponentInParent]

        [DrawFieldAttribute]

        public Transform test2;

        [Space]

        [Comment("[GetComponentInParentOnly]")]

        [GetComponentInParentOnly]

        [DrawField]

        public Transform test3;

        [Space]

        [Comment("[GetComponentInChildren]")]

        [GetComponentInChildren]

        [DrawFieldAttribute]

        public Transform test4;

        [Space]

        [Comment("[GetComponentInChildrenOnly]")]

        [GetComponentInChildrenOnly]

        [DrawFieldAttribute]

        public Transform test5;

        [Space]

        [Comment("[GetComponent]")]

        [GetComponent]

        [DrawFieldAttribute]

        public string test6;
    }
}