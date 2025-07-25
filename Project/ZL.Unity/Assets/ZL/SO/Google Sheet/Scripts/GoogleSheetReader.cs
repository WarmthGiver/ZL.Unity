using UnityEngine;

namespace ZL.Unity.SO.GoogleSheet
{
    [AddComponentMenu("ZL/SO/Google Sheet/Google Sheet Reader")]

    [DefaultExecutionOrder((int)ScriptExecutionOrder.Loading)]

    public sealed class GoogleSheetReader : MonoBehaviour
    {
        [Space]

        [PropertyField]

        [Margin]

        [Button(nameof(ReadAllSheets))]

        [UsingCustomProperty]

        [SerializeField]

        private bool readAllSheetsOnAwake = true;

        [Space]

        [SerializeField]

        private ScriptableGoogleSheet[] sheets = null;

        private void Awake()
        {
            if (readAllSheetsOnAwake == true)
            {
                ReadAllSheets();
            }
        }

        public void ReadAllSheets()
        {
            for (int i = 0; i < sheets.Length; ++i)
            {
                sheets[i].Read();
            }
        }
    }
}