#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class TextAttributeDemo : MonoBehaviour
    {
        public string test0;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"Hello World!\")]")]

        [Text("Hello World!")]

        public string test1;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"<color=#FF0000>Hello World!</color>\")]", RichText = false)]

        [Text("<color=#FF0000>Hello World!</color>")]

        public string test2;

        [Space]

        [Text("[Text(\"<color=#00FF00>Hello World!</color>\")]", RichText = false)]

        [Text("<color=#00FF00>Hello World!</color>")]

        [UsingCustomProperty]

        public string test3;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"<color=#0000FF>Hello World!</color>\")]", RichText = false)]

        [Text("<color=#0000FF>Hello World!</color>")]

        public string test4;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"Hello World!\", TextAnchor.UpperLeft, Height = 36f)]")]

        [Text("Hello World!", TextAnchor.UpperLeft, Height = 36f)]

        public string test5;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"Hello World!\", TextAnchor.MiddleCenter, Height = 36f)]")]

        [Text("Hello World!", TextAnchor.MiddleCenter, Height = 36f)]

        public string test6;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"Hello World!\", TextAnchor.LowerRight, Height = 36f)]")]

        [Text("Hello World!", TextAnchor.LowerRight, Height = 36f)]

        public string test7;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"<b>Hello World!</b>\")]", RichText = false)]

        [Text("<b>Hello World!</b>")]

        public string test8;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"<i>Hello World!</i>\")]", RichText = false)]

        [Text("<i>Hello World!</i>")]

        public string test9;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"<b><i>Hello World!</i></b>\")]", RichText = false)]

        [Text("<b><i>Hello World!</i></b>")]

        public string test10;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"Hello World!\", FontSize = 24)]")]

        [Text("Hello World!", FontSize = 24)]

        public string test11;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"Hello World!\", FontSize = 36)]")]

        [Text("Hello World!", FontSize = 36)]

        public string test12;

        [Space]

        [UsingCustomProperty]

        [Text("[Text(\"<color=#FF00FF><b><i>Hello World!</b></i></color>\", TextAnchor.MiddleCenter, FontSize = 36, Height = 72f)]", RichText = false)]

        [Text("<color=#FF00FF><b><i>Hello World!</b></i></color>", TextAnchor.MiddleCenter, FontSize = 36, Height = 72f)]

        public string test13;
    }
}