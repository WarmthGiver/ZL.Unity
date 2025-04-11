using UnityEngine;

namespace ZL.Unity.UI
{
    [DisallowMultipleComponent]

    public abstract class TextController<TTextUGUI> : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private TTextUGUI target;

        public TTextUGUI Target => target;

        public abstract string Text { get; set; }

        public abstract void SetText(int value);

        public abstract void SetText(float vaue);
    }
}