#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class PreviewAttributeDemo : MonoBehaviour
    {
        [Preview]

        [DrawFieldAttribute]

        public Texture texture;

        [Preview]

        [DrawFieldAttribute]

        public Texture2D texture2D;

        [Preview]

        [DrawFieldAttribute]

        public Sprite sprite;
    }
}