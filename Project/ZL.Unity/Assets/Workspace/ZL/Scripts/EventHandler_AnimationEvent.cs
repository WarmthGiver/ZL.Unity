using UnityEngine;

using UnityEngine.Events;

using ZL.Unity.Collections;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Event Handler (Animation Event)")]

    public sealed class EventHandler_AnimationEvent : MonoBehaviour
    {
        private AnimationEvent param = new();

        public AnimationEvent Param
        {
            set => param = value;
        }

        [Space]

        [SerializeField]

        private SerializableDictionary<string, UnityEvent<AnimationEvent>> events = new();

        public void Invoke(string key)
        {
            events[key].Invoke(param);
        }
    }
}