using UnityEngine;

namespace ZL.Unity.UI
{
    public abstract class UIWindowContent<TPoolGameObject> : MonoBehaviour
    {
        public abstract void Refresh();
    }
}