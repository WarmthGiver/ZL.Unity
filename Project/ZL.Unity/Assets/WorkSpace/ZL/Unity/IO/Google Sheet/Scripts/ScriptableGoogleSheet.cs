using GoogleSheetsToUnity;

using System;

using System.IO;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.IO;

namespace ZL.Unity.SO.GoogleSheet
{
    public abstract class ScriptableGoogleSheet<TKey, TGoogleSheetData> : ScriptableGoogleSheet<TGoogleSheetData>

        where TGoogleSheetData : ScriptableObject, IGoogleSheetData
    {
        [Space]

        [Button(nameof(Serialize))]

        [UsingCustomProperty]

        [SerializeField]

        protected SerializableDictionary<TKey, TGoogleSheetData> dataDictionary = null;

        public TGoogleSheetData this[TKey key]
        {
            get => dataDictionary[key];
        }

        protected override void OnReadSuccessful(GstuSpreadSheet sheet)
        {
            base.OnReadSuccessful(sheet);

            Serialize();
        }

        public virtual void Serialize()
        {
            dataDictionary.Clear();

            for (int i = 0; i < datas.Length; ++i)
            {
                var data = datas[i];

                dataDictionary.Add(GetDataKey(data), data);
            }

            FixedEditorUtility.SetDirty(this);
        }

        protected abstract TKey GetDataKey(TGoogleSheetData data);
    }

    public abstract class ScriptableGoogleSheet<TGoogleSheetData> : ScriptableGoogleSheet

        where TGoogleSheetData : ScriptableObject, IGoogleSheetData
    {
        [Space]

        [Button("CreateNewConfig")]

        [UsingCustomProperty]

        [SerializeField]

        private ScriptableGoogleSheetConfig sheetConfig = null;

        [Space]

        [PropertyField]

        [Margin]

        [Button(nameof(Read))]

        [Button(nameof(Write))]

        [Margin]

        [Button("AddNewData")]

        [Button("ClearDatas")]

        [Button("LoadAllDatasAtPath")]

        [UsingCustomProperty]

        [SerializeField]

        private bool containsMergedCells = false;

        [SerializeField]

        protected TGoogleSheetData[] datas = null;

        public TGoogleSheetData this[int index]
        {
            get => datas[index];
        }

        #if UNITY_EDITOR

        private string DirectoryPath
        {
            get
            {
                var assetPath = AssetDatabase.GetAssetPath(this);

                return Path.GetDirectoryName(assetPath);
            }
        }

        public void CreateNewConfig()
        {
            sheetConfig = CreateInstance<ScriptableGoogleSheetConfig>();

            AssetDatabaseEx.CreateAsset(sheetConfig, DirectoryPath, name + " Config");

            AssetDatabase.SaveAssets();

            EditorUtility.SetDirty(this);
        }

        public void AddNewData()
        {
            var data = CreateInstance<TGoogleSheetData>();

            Array.Resize(ref datas, datas.Length + 1);

            datas[^1] = data;

            AssetDatabaseEx.CreateAsset(data, DirectoryPath, 1);

            AssetDatabase.SaveAssets();

            EditorUtility.SetDirty(this);
        }

        public void ClearDatas()
        {
            datas = new TGoogleSheetData[0];

            EditorUtility.SetDirty(this);
        }

        public void LoadAllDatasAtPath()
        {
            datas = AssetDatabaseEx.LoadAllAssetsAtPath<TGoogleSheetData>(DirectoryPath);

            EditorUtility.SetDirty(this);
        }

        #endif

        public override void Read()
        {
            SpreadsheetManager.Read(sheetConfig.GetSearch(), OnReadSuccessful, containsMergedCells);
        }

        protected virtual void OnReadSuccessful(GstuSpreadSheet sheet)
        {
            for (int i = 0; i < datas.Length; ++i)
            {
                var data = datas[i];

                data.Import(sheet);

                FixedEditorUtility.SetDirty(data);
            }

            FixedDebug.Log($"Successfully read '{name}' from Google sheet.");
        }

        public void Write()
        {
            var inputData = new ValueRange(datas[0].GetHeaders());

            for (int i = 0; i < datas.Length; ++i)
            {
                inputData.Add(datas[i].Export());
            }

            SpreadsheetManager.Write(sheetConfig.GetSearch(), inputData, OnWriteSuccessful);
        }

        private void OnWriteSuccessful()
        {
            FixedEditorUtility.SetDirty(this);

            FixedDebug.Log($"Successfully written '{name}' to Google sheet.");
        }
    }

    public abstract class ScriptableGoogleSheet : ScriptableObject
    {
        public abstract void Read();
    }
}