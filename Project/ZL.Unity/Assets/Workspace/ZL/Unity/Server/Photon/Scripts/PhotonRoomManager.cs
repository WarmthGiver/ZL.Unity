using Photon.Pun;

using Photon.Realtime;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Server/Photon/Photon Room Manager")]

    [DisallowMultipleComponent]

    public sealed class PhotonRoomManager : MonoBehaviourPunCallbacks
    {
        [Space]

        [SerializeField]

        private string currentRoomName = string.Empty;

        [Space]

        [SerializeField]

        private UnityEvent eventOnCreatedRoom;

        [Space]

        [SerializeField]

        private UnityEvent eventOnCreateRoomFailed;

        [Space]

        [SerializeField]

        private UnityEvent eventOnJoinedRoom;

        [Space]

        [SerializeField]

        private UnityEvent evenOnJoinRoomFailed;
        
        [Space]

        [SerializeField]

        private UnityEvent eventOnLeftRoom;

        public List<RoomInfo> RoomList { get; private set; }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            RoomList = roomList;
        }

        public void CreateRoom(string roomName, RoomOptions roomOptions = null)
        {
            currentRoomName = roomName;

            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        public override void OnCreatedRoom()
        {
            FixedDebug.Log($"Created Room: {currentRoomName}");

            eventOnCreatedRoom.Invoke();

            JoinRoom(currentRoomName);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            FixedDebug.Log($"Create Room Failed ({returnCode}): {message}");

            eventOnCreateRoomFailed.Invoke();
        }

        public void JoinRoom(string roomName)
        {
            PhotonNetwork.JoinRoom(roomName);
        }

        public void JoinRandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            currentRoomName = PhotonNetwork.CurrentRoom.Name;

            FixedDebug.Log($"Joined Room: {currentRoomName}");

            eventOnJoinedRoom.Invoke();
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            FixedDebug.Log($"Join Room Failed ({returnCode}): {message}");

            evenOnJoinRoomFailed.Invoke();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            FixedDebug.Log($"Join Random Failed ({returnCode}): {message}");

            evenOnJoinRoomFailed.Invoke();
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            FixedDebug.Log($"Left Room: {currentRoomName}");

            eventOnLeftRoom.Invoke();
        }
    }
}