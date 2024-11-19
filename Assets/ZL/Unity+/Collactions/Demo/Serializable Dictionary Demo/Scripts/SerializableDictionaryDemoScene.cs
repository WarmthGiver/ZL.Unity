using TMPro;

using UnityEngine;

namespace ZL.Collections.Demo
{
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

        private SerializableDictionary<string, int, IntPref> intPrefsDictionary = new()
        {
            new("0", 0),

            new("1", 1),

            new("2", 2),
        };

        private void FixedUpdate()
        {
            text.text = "▼Serializable Dictionary\n▼Elements";

            foreach (var current in serializableDictionary)
            {
                text.text = $"{text.text}\n{current}";
            }

            text.text = $"{text.text}\n\n▼Int Prefs Dictionary\n▼Elements";

            foreach (var current in intPrefsDictionary)
            {
                text.text = $"{text.text}\n{current}";
            }
        }
    }
}