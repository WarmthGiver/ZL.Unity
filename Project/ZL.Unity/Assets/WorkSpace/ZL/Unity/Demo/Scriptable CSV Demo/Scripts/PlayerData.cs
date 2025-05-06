#pragma warning disable

using UnityEngine;

using ZL.Unity.IO.CSV;

namespace ZL.Unity.Demo.ScriptableCSVDemo
{
    [CreateAssetMenu(menuName = "ZL/SO/Player Data", fileName = "Player Data")]

    public sealed class PlayerData : ScriptableCSV
    {
        public string nickname;

        public int level;

        public float score;

        public override void FromCSV(string[] csv)
        {
            nickname = csv[0];

            level = int.Parse(csv[2]);

            score = float.Parse(csv[1]);
        }

        public override string ToCSV()
        {
            return $"{nickname},{level},{score}";
        }

        public override string GetHeaders()
        {
            return $"{nameof(nickname)},{nameof(level)},{nameof(score)}";
        }

        public override string ToString()
        {
            return $"[{nickname}, {level}, {score}]";
        }
    }
}