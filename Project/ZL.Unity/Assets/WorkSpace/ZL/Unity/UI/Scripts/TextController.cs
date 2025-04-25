using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class TextController : MonoBehaviour
    {
        private ITextController textController;

        public string Text
        {
            get => textController.Text;

            set => textController.Text = value;
        }

        public void SetText(int value)
        {
            textController.SetText(value);
        }

        public void SetText(float value)
        {
            textController.SetText(value);
        }

        private void Awake()
        {
            textController = GetComponent<ITextController>();
        }
    }
}