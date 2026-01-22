#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo.GoogleSheetDemo
{
    [CreateAssetMenu(menuName = "ZL/SO/Google Sheet Demo/Demo Data Sheet", fileName = "Demo Data Sheet")]

    public sealed class DemoDataSheet : ScriptableGoogleSheet<DemoData> { }
}