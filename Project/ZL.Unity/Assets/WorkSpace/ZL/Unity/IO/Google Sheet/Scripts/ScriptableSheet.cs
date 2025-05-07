using GoogleSheetsToUnity;

using UnityEngine;

using ZL.Unity.IO.CSV;

namespace ZL.Unity.IO.GoogleSheet
{
    [CreateAssetMenu(menuName = "ZL/Google Sheet/Scriptable Sheet", fileName = "Sheet")]

    public sealed class ScriptableSheet : ScriptableObject
    {
        [Space]

        [SerializeField]

        private SheetData sheetData;

        [Space]

        [SerializeField]

        private ScriptableCSVRecord[] lines;

        public void Read(bool containsMergedCells = false)
        {
            SpreadsheetManager.Read(sheetData.Search(), Write, containsMergedCells);
        }

        private void Write(GstuSpreadSheet sheet)
        {
            Debug.Log(1);

            for (int i = 0; i < lines.Length; ++i)
            {

            }
        }
    }
}