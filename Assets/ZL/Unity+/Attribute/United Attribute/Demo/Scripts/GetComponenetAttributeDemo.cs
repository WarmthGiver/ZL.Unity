#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Demo
{
    [DisallowMultipleComponent]

    public sealed class GetComponenetAttributeDemo : MonoBehaviour
    {
        [Space]

        [GetComponent]

        public Transform getComponent;
        
        [Label(" \" In Parent")]

        [GetComponentInParent]

        public Transform getComponentInParent;

        [Label(" \" In Parent Only")]

        [GetComponentInParentOnly]

        public Transform getComponentInParentOnly;

        [Label(" \" In Chilren")]

        [GetComponentInChildren]

        public Transform getComponentInChildren;

        [Label(" \" In Chilren Only")]

        [GetComponentInChildrenOnly]

        public Transform getComponentInChildrenOnly;

        [Space]

        [Label("Invalid Type*")]

        [GetComponent]

        public string getComponentString;
    }
}