using System.Collections.Generic;

using UnityEngine;

using ZL.CS.Unity.Collections;

using ZL.CS.Unity.ObjectPooling;

namespace ZL.CS.Unity.UI
{
    public abstract class ContentUIWindow<TUIContent> : UIWindow

        where TUIContent : UIWindowContent<TUIContent>
    {
        [SerializeField]

        protected SerializableDictionary<string, GameObjectPool<TUIContent>> uiContentPools;

        protected List<TUIContent> uiContentList = new();

        protected int uiContentCount;

        protected void ClearContents()
        {
            foreach (var uiContent in uiContentList)
            {
                uiContent.gameObject.SetActive(false);
            }
        }

        protected virtual void RefreshContents()
        {
            foreach (var content in uiContentList)
            {
                content.Refresh();
            }
        }
    }
}