using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.CSVDemo
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

        private string filePath = "Assets/ZL/Unity/Core/Demos/CSV Demo/CSV Files/PlayerDatas.csv";

        [Space]

        [SerializeField]

        private List<PlayerData> playerDatas;

        public void LoadData()
        {
            CSVManager.TryLoad(filePath, out playerDatas);
        }

        public void SaveData()
        { 
            CSVManager.Save(filePath, playerDatas);
        }
    }

    [Serializable]

    public sealed class PlayerData : ICSVConvertible
    {
        public string name;

        public float score;

        public int level;

        public void FromCSV(string[] CSV)
        {
            name = CSV[0];

            score = float.Parse(CSV[1]);

            level = int.Parse(CSV[2]);
        }

        public string ToCSV()
        {
            return $"{name},{score},{level}";
        }

        public string GetCSVHeader()
        {
            return "Name,Score,Level";
        }

        public override string ToString()
        {
            return $"[{name}, {score}, {level}]";
        }
    }
}