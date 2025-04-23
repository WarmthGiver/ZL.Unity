#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.IO;

namespace ZL.Demo.CSVDemo
{
    [Serializable]

    public sealed class PlayerData : ICSVConvertible
    {
        public string name;

        public float score;

        public int level;

        public void FromCSV(string[] csv)
        {
            name = csv[0];

            score = float.Parse(csv[1]);

            level = int.Parse(csv[2]);
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