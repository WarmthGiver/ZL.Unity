#pragma warning disable

using TMPro;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.WrapprDemo
{
    [AddComponentMenu("")]

    public sealed class WrapprDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TMP_Text text = null;

        [Space]

        public string[][] array2D = null;

        [Space]

        public Wrapper<string[]>[] wrappedArray2D = null;

        [Space]

        public Wrapper<Wrapper<string[]>[]>[] wrappedArrayD3 = null;

        private void FixedUpdate()
        {
            text.text =

                "��Wrapped Array D2\n" +

                "��Elements\n";

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

                "��Wrapped Array D3\n" +

                "��Elements\n";

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