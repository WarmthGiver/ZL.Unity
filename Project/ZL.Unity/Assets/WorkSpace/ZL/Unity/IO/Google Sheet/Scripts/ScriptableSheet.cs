using GoogleSheetsToUnity;

using UnityEngine;

namespace ZL.Unity.IO.GoogleSheet
{
    [CreateAssetMenu(menuName = "ZL/Google Sheet/Sheet", fileName = "Sheet")]

    public class ScriptableSheet : ScriptableObject
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [PropertyField]

        [Margin]

        [Button(nameof(Read))]

        [Button(nameof(Write))]

        private SheetConfig sheetConfig;

        [Space]

        [SerializeField]

        private ScriptableSheetData[] datas;

        public void Read()
        {
            Read(false);
        }

        public void Read(bool containsMergedCells)
        {
            SpreadsheetManager.Read(sheetConfig.GetSearch(), OnReadSuccessful, containsMergedCells);
        }

        protected virtual void OnReadSuccessful(GstuSpreadSheet sheet)
        {
            FixedDebug.Log($"'{name}' read successful.");

            ImportAllDatas(sheet);
        }

        protected void ImportAllDatas(GstuSpreadSheet sheet)
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

                SpreadsheetManager.Write(sheetConfig.GetSearch(data), new ValueRange(data.Export()), OnWriteSuccessful);
            }
        }

        protected virtual void OnWriteSuccessful()
        {
            FixedDebug.Log($"'{name}' write successful.");
        }
    }
}