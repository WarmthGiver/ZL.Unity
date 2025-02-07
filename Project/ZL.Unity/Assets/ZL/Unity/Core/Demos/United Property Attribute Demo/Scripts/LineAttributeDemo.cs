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

        [Comment("[Line(1f, \"#ff0000\")]")]

        [Line(1f, "#ff0000")]

        [DrawFieldAttribute]

        public string test1;



        [Space]

        [Comment("[Line(2f, \"#ff8000\")]")]

        [Line(2f, "#ff8000")]

        [DrawFieldAttribute]

        public string test2;



        [Space]

        [Comment("[Line(3f, \"#ffff00\")]")]

        [Line(3f, "#ffff00")]

        [DrawFieldAttribute]

        public string test3;



        [Space]

        [Comment("[Line(4f, \"#80ff00\")]")]

        [Line(4f, "#80ff00")]

        [DrawFieldAttribute]

        public string test4;



        [Space]

        [Comment("[Line(5f, \"#00ff00\")]")]

        [Line(5f, "#00ff00")]

        [DrawFieldAttribute]

        public string test5;



        [Space]

        [Comment("[Line(6f, \"#00ff80\")]")]

        [Line(6f, "#00ff80")]

        [DrawFieldAttribute]

        public string test6;



        [Space]

        [Comment("[Line(7f, \"#00ffff\")]")]

        [Line(7f, "#00ffff")]

        [DrawFieldAttribute]

        public string test7;



        [Space]

        [Comment("[Line(8f, \"#0000ff\")]")]

        [Line(8f, "#0000ff")]

        [DrawFieldAttribute]

        public string test8;



        [Space]

        [Comment("[Line(9f, \"#8000ff\")]")]

        [Line(9f, "#8000ff")]

        [DrawFieldAttribute]

        public string test9;



        [Space]

        [Comment("[Line(10f, \"#ff00ff\")]")]

        [Line(10f, "#ff00ff")]

        [DrawFieldAttribute]

        public string test10;



        [Space]

        [Comment("[Line(11f, \"#ff0080\")]")]

        [Line(11f, "#ff0080")]

        [DrawFieldAttribute]

        public string test11;
    }
}