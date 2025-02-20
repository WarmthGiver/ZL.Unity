using UnityEngine;

namespace ZL.CS.Unity.UI
{
    public abstract class UIWindowContent<TPoolGameObject> : MonoBehaviour
    {
        public abstract void Refresh();
    }
}