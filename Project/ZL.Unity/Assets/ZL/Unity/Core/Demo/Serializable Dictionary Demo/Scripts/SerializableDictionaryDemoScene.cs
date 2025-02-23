#pragma warning disable

using TMPro;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.IO;

namespace ZL.Unity.SerializableDictionaryDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class SerializableDictionaryDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private TMP_Text text;

        [Space]

        [SerializeField]

        private SerializableDictionary<string, int> serializableDictionary = new()
        {
            { "0", 0 },

            { "1", 1 },

            { "2", 2 },
        };

        [Space]

        [SerializeField]

        private SerializableDictionary<string, int, IntPrefs> intPrefsDictionary = new()
        {
            new("0", 0),

            new("1", 1),

            new("2", 2),
        };

        private void FixedUpdate()
        {
            text.text =
                
                "▼Serializable Dictionary\n" +

                "▼Elements\n";

            foreach (var element in serializableDictionary)
            {
                text.text += $"\n{element}";
            }

            text.text +=

                "\n" +

                "\n" +

                "▼Int Prefs Dictionary\n" +

                "▼Elements\n";

            foreach (var element in intPrefsDictionary)
            {
                text.text += $"\n{element}";
            }
        }
    }
}