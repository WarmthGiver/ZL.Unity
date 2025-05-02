#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.Demo.CSVDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

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

        private PlayerData[] playerDatas;

        public void LoadData()
        {
            CSVManager.TryLoad(filePath, out playerDatas);
        }

        public void SaveData()
        { 
            CSVManager.Save(filePath, playerDatas);
        }
    }
}