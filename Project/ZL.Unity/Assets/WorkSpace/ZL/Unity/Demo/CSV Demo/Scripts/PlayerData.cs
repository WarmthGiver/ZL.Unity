#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.Demo.CSVDemo
{
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