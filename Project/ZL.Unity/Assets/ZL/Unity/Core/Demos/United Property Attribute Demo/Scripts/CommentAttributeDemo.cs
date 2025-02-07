#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class CommentAttributeDemo : MonoBehaviour
    {
        public string test0;


        [Space]

        [Comment("[Comment(\"Hello World!\")]")]

        [Comment("Hello World!")]

        [DrawFieldAttribute]

        public string test1;



        [Space]

        [Comment("[Comment(\"Hello World!\", \"#FF0000\")]")]

        [Comment("Hello World!", "#FF0000")]

        [DrawFieldAttribute]

        public string test2;



        [Space]

        [Comment("[Comment(\"Hello World!\", \"#00FF00\")]")]

        [Comment("Hello World!", "#00FF00")]

        [DrawFieldAttribute]

        public string test3;



        [Space]

        [Comment("[Comment(\"Hello World!\", \"#0000FF\")]")]

        [Comment("Hello World!", "#0000FF")]

        [DrawFieldAttribute]

        public string test4;



        [Space]

        [Comment("[Comment(\"Hello World!\", FontStyle.Normal)]")]

        [Comment("Hello World!", FontStyle.Normal)]

        [DrawFieldAttribute]

        public string test5;



        [Space]

        [Comment("[Comment(\"Hello World!\", FontStyle.Bold)]")]

        [Comment("Hello World!", FontStyle.Bold)]

        [DrawFieldAttribute]

        public string test6;



        [Space]

        [Comment("[Comment(\"Hello World!\", FontStyle.BoldAndItalic)]")]

        [Comment("Hello World!", FontStyle.BoldAndItalic)]

        [DrawFieldAttribute]

        public string test7;



        [Space]

        [Comment("[Comment(\"Hello World!\", fontSize: 24)]")]

        [Comment("Hello World!", fontSize: 24)]

        [DrawFieldAttribute]

        public string test8;



        [Space]

        [Comment("[Comment(\"Hello World!\", fontSize: 36)]")]

        [Comment("Hello World!", fontSize: 36)]

        [DrawFieldAttribute]

        public string test9;



        [Space]

        [Comment("[Comment(\"Hello World!\", fontSize: 36, FontStyle.BoldAndItalic, \"#FF00FF\")]")]

        [Comment("Hello World!", fontSize: 36, FontStyle.BoldAndItalic, "#FF00FF")]

        [DrawFieldAttribute]

        public string test10;
    }
}