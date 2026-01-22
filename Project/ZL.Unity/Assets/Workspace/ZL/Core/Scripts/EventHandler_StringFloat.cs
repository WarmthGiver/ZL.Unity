using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Event Handler (String, Float)")]

    public sealed class EventHandler_StringFloat : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private float param = 0f;

        public float Param
        {
            set => param = value;
        }

        [Space]

        [SerializeField]

        private SerializableDictionary<string, UnityEvent<string, float>> events =
            
            new SerializableDictionary<string, UnityEvent<string, float>>();

        public void Invoke(string key)
        {
            events[key].Invoke(key, param);
        }
    }
}