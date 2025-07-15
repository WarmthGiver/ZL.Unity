#pragma warning disable

using UnityEngine;

using ZL.Unity.SO.GoogleSheet;

namespace ZL.Unity.Demo.GoogleSheetDemo
{
    [CreateAssetMenu(menuName = "ZL/SO/Google Sheet Demo/Demo Data Sheet", fileName = "Demo Data Sheet")]

    public sealed class DemoDataSheet : ScriptableGoogleSheet<DemoData> { }
}