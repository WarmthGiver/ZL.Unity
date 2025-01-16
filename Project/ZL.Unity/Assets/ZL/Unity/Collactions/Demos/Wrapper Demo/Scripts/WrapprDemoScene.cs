#pragma warning disable

using TMPro;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Collections.Demo
{
    public class WrapprDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TMP_Text text;

        [Space]

        public string[][] array2D;

        [Space]

        public Wrapper<string[]>[] wrappedArray2D;

        [Space]

        public Wrapper<Wrapper<string[]>[]>[] wrappedArrayD3;

        private void FixedUpdate()
        {
            text.text =

                "°ÂWrapped Array D2\n" +
                "°ÂElements\n";

            foreach (var wrappedArray1D in wrappedArray2D)
            {
                text.text += "\n[ ";

                foreach (var element in wrappedArray1D.value)
                {
                    text.text += $"{element}, ";
                }

                text.text += "]";
            }

            text.text +=

                "\n" +
                "\n" +
                "°ÂWrapped Array D3\n" +
                "°ÂElements\n";

            foreach (var wrappedArray2D in wrappedArrayD3)
            {
                foreach (var wrappedArray1D in wrappedArray2D.value)
                {
                    text.text += "\n[ ";

                    foreach (var element in wrappedArray1D.value)
                    {
                        text.text += $"{element}, ";
                    }

                    text.text += "]";
                }

                text.text += "\n";
            }
        }
    }
}