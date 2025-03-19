using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class PhotonRoomListDisplayer : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private Transform container;

        [Space]

        [SerializeField]

        private PhotonRoomListItem item;

        public void CreateItem(PhotonRoomInfo info)
        {
            var item = Instantiate(this.item, container);
        }
    }

    public class PhotonRoomInfo
    {

    }
}