using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class PhotonRoomManager : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private PhotonRoomListDisplayer roomList;

        public void CreateRoom()
        {

        }
    }
}