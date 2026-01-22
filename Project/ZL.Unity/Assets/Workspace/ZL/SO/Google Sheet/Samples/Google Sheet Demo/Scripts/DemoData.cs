#pragma warning disable

using GoogleSheetsToUnity;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Demo.GoogleSheetDemo
{
    [CreateAssetMenu(menuName = "ZL/SO/Google Sheet Demo/Demo Data", fileName = "Demo Data")]

    public sealed class DemoData : ScriptableGoogleSheetData
    {
        [Space]

        [SerializeField]

        private string nickname = "";

        public string Nickname => nickname;

        [SerializeField]

        private int level = 0;

        public int Level => level;

        [SerializeField]

        private float speed = 0f;

        public float Speed => speed;

        public override List<string> GetHeaders()
        {
            return new List<string>()
            {
                nameof(name),

                nameof(nickname),

                nameof(level),

                nameof(speed),
            };
        }

        public override void Import(GstuSpreadSheet sheet)
        {
            nickname = sheet[name, nameof(nickname)].value;

            level = int.Parse(sheet[name, nameof(level)].value);

            speed = float.Parse(sheet[name, nameof(speed)].value);
        }

        public override List<string> Export()
        {
            return new List<string>()
            {
                name.ToString(),

                nickname.ToString(),
                
                level.ToString(),
                
                speed.ToString(),
            };
        }
    }
}