#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class LineAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [Text("[Line]")]

        [Line]

        [DrawCustomProperty]

        public string test1;



        [Space]

        [Text("[Line(Margin = 2)]")]

        [Line(Margin = 2)]

        [DrawCustomProperty]

        public string test2;



        [Space]

        [Text("[Line(\"#ff0000\")]")]

        [Line("#ff0000")]

        [DrawCustomProperty]

        public string test3;



        [Space]

        [Text("[Line(\"#ff8000\", Thickness = 2)]")]

        [Line("#ff8000", Thickness = 2)]

        [DrawCustomProperty]

        public string test4;



        [Space]

        [Text("[Line(\"#ffff00\", Thickness = 3)]")]

        [Line("#ffff00", Thickness = 3)]

        [DrawCustomProperty]

        public string test5;



        [Space]

        [Text("[Line(\"#80ff00\", Thickness = 4)]")]

        [Line("#80ff00", Thickness = 4)]

        [DrawCustomProperty]

        public string test6;



        [Space]

        [Text("[Line(\"#00ff00\", Thickness = 5)]")]

        [Line("#00ff00", Thickness = 5)]

        [DrawCustomProperty]

        public string test7;



        [Space]

        [Text("[Line(\"#00ff80\", Thickness = 6)]")]

        [Line("#00ff80", Thickness = 6)]

        [DrawCustomProperty]

        public string test8;



        [Space]

        [Text("[Line(\"#00ffff\", Thickness = 7)]")]

        [Line("#00ffff", Thickness = 7)]

        [DrawCustomProperty]

        public string test9;



        [Space]

        [Text("[Line(\"#0000ff\", Thickness = 8)]")]

        [Line("#0000ff", Thickness = 8)]

        [DrawCustomProperty]

        public string test10;



        [Space]

        [Text("[Line(\"#8000ff\", Thickness = 9)]")]

        [Line("#8000ff", Thickness = 9)]

        [DrawCustomProperty]

        public string test11;



        [Space]

        [Text("[Line(\"#ff00ff\", Thickness = 10)]")]

        [Line("#ff00ff", Thickness = 10)]

        [DrawCustomProperty]

        public string test12;



        [Space]

        [Text("[Line(\"#ff0080\", Thickness = 11)]")]

        [Line("#ff0080", Thickness = 11)]

        [DrawCustomProperty]

        public string test13;
    }
}