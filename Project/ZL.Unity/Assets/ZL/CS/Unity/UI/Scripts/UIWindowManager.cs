using System.Collections.Generic;

using UnityEngine;

namespace ZL.CS.Unity.UI
{
    [AddComponentMenu("ZL/UI/UI Window Manager")]

    [DisallowMultipleComponent]

    public sealed class UIWindowManager : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private Canvas canvas;

        private void FixedUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Escape) == true)
            {
                CloseLast();
            }
        }

        public void CloseLast()
        {
            if (transform.childCount > 0)
            {
                var uiWindow = transform.GetLastChild();

                uiWindow.gameObject.SetActive(false);
            }
        }
    }
}