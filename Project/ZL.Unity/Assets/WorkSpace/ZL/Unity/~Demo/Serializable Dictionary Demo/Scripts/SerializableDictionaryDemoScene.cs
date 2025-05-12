#pragma warning disable

using TMPro;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.IO;

namespace ZL.Unity.Demo.SerializableDictionaryDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class SerializableDictionaryDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TextMeshProUGUI textUI;

        [Space]

        [SerializeField]

        private SerializableDictionary<string, int> serializableDictionary = new SerializableDictionary<string, int>()
        {
            { "0", 0 },

            { "1", 1 },

            { "2", 2 },
        };

        [Space]

        [SerializeField]

        private SerializableDictionary<string, int, IntPref> intPrefDictionary = new SerializableDictionary<string, int, IntPref>()
        {
            new IntPref("0", 0),

            new IntPref("1", 1),

            new IntPref("2", 2),
        };

        private void FixedUpdate()
        {
            textUI.text =
                
                "▼Serializable Dictionary\n" +

                "▼Elements\n";

            foreach (var element in serializableDictionary)
            {
                textUI.text += $"\n{element}";
            }

            textUI.text +=

                "\n" +

                "\n" +

                "▼Int Pref Dictionary\n" +

                "▼Elements\n";

            foreach (var element in intPrefDictionary)
            {
                textUI.text += $"\n{element}";
            }
        }
    }
}