using GoogleSheetsToUnity;

using UnityEngine;

namespace ZL.Unity.IO.GoogleSheet
{
    [CreateAssetMenu(menuName = "ZL/Google Sheet/Sheet", fileName = "Sheet")]

    public sealed class ScriptableSheet : ScriptableObject
    {
        [Space]

        [SerializeField]

        private SheetConfig sheetConfig = null;

        [Space]

        [PropertyField]

        [Margin]

        [Button(nameof(Read))]

        [Button(nameof(Write))]

        [UsingCustomProperty]

        [SerializeField]

        private bool containsMergedCells = false;

        [Space]

        [SerializeField]

        private ScriptableSheetData[] datas = null;

        public void Read()
        {
            SpreadsheetManager.Read(sheetConfig.GetSearch(), ImportAllDatas, containsMergedCells);
        }

        private void ImportAllDatas(GstuSpreadSheet sheet)
        {
            for (int i = 0; i < datas.Length; ++i)
            {
                datas[i].Import(sheet);
            }
        }

        public void Write()
        {
            for (int i = 0; i < datas.Length; ++i)
            {
                var data = datas[i];

                SpreadsheetManager.Write(sheetConfig.GetSearch(data), new ValueRange(data.Export()), null);
            }
        }
    }
}