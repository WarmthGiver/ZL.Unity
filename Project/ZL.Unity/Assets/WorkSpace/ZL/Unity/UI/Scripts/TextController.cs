using UnityEngine;

namespace ZL.Unity.UI
{
    public abstract class TextController<TTextUGUI> : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private TTextUGUI target;

        public TTextUGUI Target
        {
            get => target;
        }

        public abstract string Text { get; set; }

        private void Reset()
        {
            this.DisallowMultiple();
        }

        public abstract void SetText(int value);

        public abstract void SetText(float vaue);
    }
}