#pragma warning disable

using UnityEngine;

using ZL.Unity.IO.GoogleSheet;

namespace ZL.Unity.Demo.GoogleSheetDemo
{
    [AddComponentMenu("")]

    public sealed class GoogleSheetDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private ScriptableSheet[] sheets;

        private void Awake()
        {
            foreach (var sheet in sheets)
            {
                sheet.Read();
            }
        }
    }
}