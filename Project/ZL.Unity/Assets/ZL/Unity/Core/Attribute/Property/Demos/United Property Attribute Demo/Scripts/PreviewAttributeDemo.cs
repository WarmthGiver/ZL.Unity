#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo
{
    public sealed class PreviewAttributeDemo : MonoBehaviour
    {
        [Space]

        [Preview]

        public Texture texture;

        [Preview]

        public Texture2D texture2D;

        [Preview]

        public Sprite sprite;
    }
}