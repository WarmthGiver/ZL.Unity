#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttributeDemo
{
    [AddComponentMenu("")]

    public sealed class LineAttributeDemo : MonoBehaviour
    {
        [Space]

        public string test0;

        [UsingCustomProperty]

        [Space]

        [Text("[Line]")]

        [Line]

        public string test1;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(Margin = 2)]")]

        [Line(Margin = 2)]

        public string test2;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#ff0000\")]")]

        [Line("#ff0000")]

        public string test3;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#ff8000\", Thickness = 2)]")]

        [Line("#ff8000", Thickness = 2)]

        public string test4;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#ffff00\", Thickness = 3)]")]

        [Line("#ffff00", Thickness = 3)]

        public string test5;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#80ff00\", Thickness = 4)]")]

        [Line("#80ff00", Thickness = 4)]

        public string test6;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#00ff00\", Thickness = 5)]")]

        [Line("#00ff00", Thickness = 5)]

        public string test7;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#00ff80\", Thickness = 6)]")]

        [Line("#00ff80", Thickness = 6)]

        public string test8;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#00ffff\", Thickness = 7)]")]

        [Line("#00ffff", Thickness = 7)]

        public string test9;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#0000ff\", Thickness = 8)]")]

        [Line("#0000ff", Thickness = 8)]

        public string test10;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#8000ff\", Thickness = 9)]")]

        [Line("#8000ff", Thickness = 9)]

        public string test11;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#ff00ff\", Thickness = 10)]")]

        [Line("#ff00ff", Thickness = 10)]

        public string test12;

        [Space]

        [UsingCustomProperty]

        [Text("[Line(\"#ff0080\", Thickness = 11)]")]

        [Line("#ff0080", Thickness = 11)]

        public string test13;
    }
}