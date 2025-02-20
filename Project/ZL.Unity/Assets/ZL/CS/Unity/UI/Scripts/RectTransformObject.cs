using UnityEngine;

namespace ZL.CS.Unity.UI
{
    [RequireComponent(typeof(RectTransform))]

    public abstract class RectTransformObject : MonoBehaviour
    {
        [SerializeField, GetComponent, HideInInspector]

        protected RectTransform rectTransform;
    }
}