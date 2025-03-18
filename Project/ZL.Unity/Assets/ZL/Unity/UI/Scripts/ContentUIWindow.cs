using System.Collections.Generic;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.ObjectPooling;

namespace ZL.Unity.UI
{
    public abstract class ContentUIWindow<TUIContent> : WindowUGUI

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