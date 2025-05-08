#pragma warning disable

using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.IO.GoogleSheet;

namespace ZL.Unity.Demo.GoogleSheetDemo
{
    [AddComponentMenu("")]

    public sealed class GoogleSheetDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Button(nameof(Read))]

        [Button(nameof(Write))]

        [PropertyField]

        private Wrapper<ScriptableSheet[]> sheets;

        public void Read()
        {
            foreach (var sheet in sheets.value)
            {
                sheet.Read();
            }
        }

        public void Write()
        {
            foreach (var sheet in sheets.value)
            {
                sheet.Write();
            }
        }
    }
}