#pragma warning disable

using GoogleSheetsToUnity;

using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.IO.GoogleSheet;

namespace ZL.Unity.Demo.GoogleSheetDemo
{
    [CreateAssetMenu(menuName = "ZL/Google Sheet Demo/Demo Data", fileName = "Demo Data")]

    public sealed class DemoData : ScriptableSheetData
    {
        [Space]

        [SerializeField]

        private string nickname;

        public string Nickname => nickname;

        [SerializeField]

        private int level;

        public int Level => level;

        [SerializeField]

        private float speed;

        public float Speed => speed;

        public override void Import(GstuSpreadSheet sheet)
        {
            base.Import(sheet);

            nickname = sheet[name, nameof(nickname)].value;

            level = int.Parse(sheet[name, nameof(level)].value);

            speed = float.Parse(sheet[name, nameof(speed)].value);
        }

        public override List<string> Export()
        {
            return new()
            {
                name,

                nickname,
                
                level.ToString(),
                
                speed.ToString(),
            };
        }
    }
}