#pragma warning disable

using GoogleSheetsToUnity;

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.Demo.CSVDemo
{
    [AddComponentMenu("")]

    public sealed class CSVDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Button(nameof(LoadData))]

        [Button(nameof(SaveData))]

        private string filePath = string.Empty;

        [Space]

        [SerializeField]

        private DemoData[] datas;

        public void LoadData()
        {
            CSVManager.TryLoad(filePath, out datas);
        }

        public void SaveData()
        { 
            CSVManager.Save(filePath, datas);
        }
    }
}