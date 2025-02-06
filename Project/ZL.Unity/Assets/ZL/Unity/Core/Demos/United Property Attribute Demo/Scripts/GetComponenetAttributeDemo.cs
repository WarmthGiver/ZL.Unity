#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.UnitedPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class GetComponenetAttributeDemo : MonoBehaviour
    {
        [Space]

        [GetComponent]

        public Transform getComponent;
        
        [Label(Text = " \" In Parent")]

        [GetComponentInParent]

        public Transform getComponentInParent;

        [Label(Text = " \" In Parent Only")]

        [GetComponentInParentOnly]

        public Transform getComponentInParentOnly;

        [Label(Text = " \" In Chilren")]

        [GetComponentInChildren]

        public Transform getComponentInChildren;

        [Label(Text = " \" In Chilren Only")]

        [GetComponentInChildrenOnly]

        public Transform getComponentInChildrenOnly;

        [Space]

        [GetComponent]

        public string invalidTypeTest;
    }
}