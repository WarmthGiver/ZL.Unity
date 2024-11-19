using System.Collections.Generic;

using UnityEngine;

namespace ZL.UI
{
    [AddComponentMenu("ZL/UI/UI Window Manager")]

    [DisallowMultipleComponent]

    public sealed class UIWindowManager : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private Canvas canvas;

        private void FixedUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                CloseLast();
            }
        }

        public void CloseLast()
        {
            if (transform.childCount > 0)
            {
                var uiWindow = transform.GetLastChild();

                uiWindow.SetActive(false);
            }
        }
    }
}