#pragma warning disable

using System.Text;

using TMPro;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Demo.SerializableDictionaryDemo
{
    [AddComponentMenu("")]

    public sealed class SerializableDictionaryDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextMeshProUGUI textUI = null;

        [Space]

        [SerializeField]

        private SerializableDictionary<string, int> serializableDictionary = new()
        {
            { "0", 0 },

            { "1", 1 },

            { "2", 2 },
        };

        private StringBuilder stringBuilder = new();

        private void FixedUpdate()
        {
            stringBuilder.Clear();

            stringBuilder.AppendLine("▼Serializable Dictionary");

            stringBuilder.AppendLine("▼Items");

            foreach (var item in serializableDictionary)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            textUI.text = stringBuilder.ToString();
        }
    }
}