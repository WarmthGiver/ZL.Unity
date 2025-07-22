using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Force Layout Rebuilder")]

    [ExecuteAlways]

    public sealed class ForceLayoutRebuilder : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [PropertyField]

        [ReadOnly(false)]

        [Button(nameof(ForceRebuildLayout))]

        [UsingCustomProperty]

        [SerializeField]

        private RectTransform rectTransform = null;

        private void Start()
        {
            ForceRebuildLayout();

            if (Application.isPlaying == true)
            {
                enabled = false;
            }
        }

        public void ForceRebuildLayout()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        }
    }
}