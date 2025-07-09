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

        [Button(nameof(LoadData))]

        [Button(nameof(SaveData))]

        [UsingCustomProperty]

        [SerializeField]

        private string filePath = "";

        [Space]

        [SerializeField]

        private DemoData[] datas = null;

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