#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.Demo.CSVDemo
{
    [Serializable]

    public sealed class PlayerData : ICSVRecord
    {
        public string nickname;

        public int level;

        public float score;

        public void FromCSVRecord(string[] values)
        {
            nickname = values[0];

            level = int.Parse(values[2]);

            score = float.Parse(values[1]);
        }

        public string ToCSVRecord()
        {
            return $"{nickname},{level},{score}";
        }

        public string GetHeader()
        {
            return $"{nameof(nickname)},{nameof(level)},{nameof(score)}";
        }

        public override string ToString()
        {
            return $"[{nickname}, {level}, {score}]";
        }
    }
}