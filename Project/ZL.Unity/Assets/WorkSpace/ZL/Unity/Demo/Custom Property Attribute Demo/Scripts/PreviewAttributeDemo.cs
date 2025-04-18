#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class PreviewAttributeDemo : MonoBehaviour
    {
        [Space]

        [UsingCustomProperty]

        [PropertyField]

        [Preview]

        public Texture test1;

        [Space]

        [UsingCustomProperty]

        [PropertyField]

        [Preview]

        public Texture2D test2;

        [Space]

        [UsingCustomProperty]

        [PropertyField]

        [Preview]

        public Sprite test3;

        [Space]

        [UsingCustomProperty]

        [PropertyField]

        [Preview]

        public GameObject test4;

        [Space]

        [UsingCustomProperty]

        [PropertyField]

        [Preview]

        public Material test5;
    }
}