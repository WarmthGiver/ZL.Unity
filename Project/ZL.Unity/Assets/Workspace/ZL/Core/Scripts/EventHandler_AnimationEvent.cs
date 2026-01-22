using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Event Handler (Animation Event)")]

    public sealed class EventHandler_AnimationEvent : MonoBehaviour
    {
        private AnimationEvent param = new AnimationEvent();

        public AnimationEvent Param
        {
            set => param = value;
        }

        [Space]

        [SerializeField]

        private SerializableDictionary<string, UnityEvent<AnimationEvent>> events =
            
            new SerializableDictionary<string, UnityEvent<AnimationEvent>>();

        public void Invoke(string key)
        {
            events[key].Invoke(param);
        }
    }
}