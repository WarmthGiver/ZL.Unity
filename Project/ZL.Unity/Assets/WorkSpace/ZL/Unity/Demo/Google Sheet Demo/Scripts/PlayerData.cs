#pragma warning disable

using UnityEngine;

using ZL.Unity.IO.CSV;

using ZL.Unity.IO.GoogleSheet;

namespace ZL.Unity.Demo.ScriptableCSVDemo
{
    [CreateAssetMenu(menuName = "ZL/Player Data", fileName = "Player Data")]

    public sealed class PlayerData : ScriptableCSVRecord
    {
        [Space]

        [SerializeField]

        private string nickname;

        public string Nickname => nickname;

        [SerializeField]

        private int level;

        public int Level => level;

        [SerializeField]

        private float score;

        public float Score => score;

        public override string GetHeader()
        {
            return $"{nameof(nickname)},{nameof(level)},{nameof(score)}";
        }

        public override void FromCSVRecord(string[] csvRecord)
        {
            nickname = csvRecord[0];

            level = int.Parse(csvRecord[2]);

            score = float.Parse(csvRecord[1]);
        }

        public override string ToCSVRecord()
        {
            return $"{nickname},{level},{score}";
        }

        public override string ToString()
        {
            return $"[{nickname}, {level}, {score}]";
        }
    }
}