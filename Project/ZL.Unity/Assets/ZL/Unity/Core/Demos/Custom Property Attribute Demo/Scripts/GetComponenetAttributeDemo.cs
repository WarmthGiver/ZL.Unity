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

        [Text("[GetComponent]")]

        [GetComponent]

        [DrawCustomProperty]

        public Transform test1;



        [Space]

        [Text("[GetComponentInParent]")]

        [GetComponentInParent]

        [DrawCustomProperty]

        public Transform test2;



        [Space]

        [Text("[GetComponentInParentOnly]")]

        [GetComponentInParentOnly]

        [DrawCustomProperty]

        public Transform test3;



        [Space]

        [Text("[GetComponentInChildren]")]

        [GetComponentInChildren]

        [DrawCustomProperty]

        public Transform test4;



        [Space]

        [Text("[GetComponentInChildrenOnly]")]

        [GetComponentInChildrenOnly]

        [DrawCustomProperty]

        public Transform test5;



        [Space]

        [Text("[GetComponent]")]

        [GetComponent]

        [DrawCustomProperty]

        public string test6;
    }
}