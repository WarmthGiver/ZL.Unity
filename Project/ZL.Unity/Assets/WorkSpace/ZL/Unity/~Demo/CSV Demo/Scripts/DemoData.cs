#pragma warning disable

using System;

using System.Collections.Generic;

using UnityEngine;

using ZL.CS.IO.CSV;

namespace ZL.Unity.Demo.CSVDemo
{
    [Serializable]

    public class DemoData : ICSVData
    {
        [Space]

        [SerializeField]

        private string nickname = "";

        public string Nickname => nickname;

        [SerializeField]

        private int level = 0;

        public int Level => level;

        [SerializeField]

        private float speed = 0;

        public float Speed => speed;

        public string GetHeader()
        {
            return $"{nameof(nickname)},{nameof(level)},{nameof(speed)}";
        }

        public void Import(string[] csvRecord)
        {
            nickname = csvRecord[0];

            level = int.Parse(csvRecord[1]);

            speed = float.Parse(csvRecord[2]);
        }

        public string Export()
        {
            return $"{nickname},{level},{speed}";
        }
    }
}