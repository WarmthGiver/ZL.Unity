#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.CustomPropertyAttribute
{
    [AddComponentMenu("")]

    public sealed class HelpBoxAttributeDemo : MonoBehaviour
    {
        public string test0;



        [Space]

        [DrawCustomProperty]

        [Text("[MessageBox(\"This is message.\")]")]

        [MessageBox("This is message.")]

        public string test1;



        [Space]

        [DrawCustomProperty]

        [Text("[InfoBox(\"This is info message.\")]")]

        [InfoBox("This is info message.")]

        public string test2;



        [Space]

        [DrawCustomProperty]

        [Text("[WarningBox(\"This is warning message.\")]")]

        [WarningBox("This is warning message.")]

        public string test3;



        [Space]

        [DrawCustomProperty]

        [Text("[ErrorBox(\"This is error message.\")]")]

        [ErrorBox("This is error message.")]

        public string test4;
    }
}