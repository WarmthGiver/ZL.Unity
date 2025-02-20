#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.CS.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class GetComponenetAttributeDemo : MonoBehaviour
    {
        [Space]

        [Text("[GetComponent]")]

        [GetComponent]

        [UsingCustomProperty]

        public Transform test1;



        [Space]

        [Text("[GetComponentInParent]")]

        [GetComponentInParent]

        [UsingCustomProperty]

        public Transform test2;



        [Space]

        [Text("[GetComponentInParentOnly]")]

        [GetComponentInParentOnly]

        [UsingCustomProperty]

        public Transform test3;



        [Space]

        [Text("[GetComponentInChildren]")]

        [GetComponentInChildren]

        [UsingCustomProperty]

        public Transform test4;



        [Space]

        [Text("[GetComponentInChildrenOnly]")]

        [GetComponentInChildrenOnly]

        [UsingCustomProperty]

        public Transform test5;



        [Space]

        [Text("[GetComponent]")]

        [GetComponent]

        [UsingCustomProperty]

        public string test6;
    }
}