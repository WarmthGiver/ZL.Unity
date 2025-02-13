#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class PreviewAttributeDemo : MonoBehaviour
    {
        [Space]

        [DrawCustomProperty]

        [PropertyField]

        [Preview]

        public Texture test1;



        [Space]

        [DrawCustomProperty]

        [PropertyField]

        [Preview]

        public Texture2D test2;



        [Space]

        [DrawCustomProperty]

        [PropertyField]

        [Preview]

        public Sprite test3;



        [Space]

        [DrawCustomProperty]

        [PropertyField]

        [Preview]

        public GameObject test4;



        [Space]

        [DrawCustomProperty]

        [PropertyField]

        [Preview]

        public Material test5;
    }
}