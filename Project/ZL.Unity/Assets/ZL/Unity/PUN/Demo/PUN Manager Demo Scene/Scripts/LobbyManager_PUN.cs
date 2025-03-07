using Photon.Pun;

using Photon.Realtime;

using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity.Server.PUN
{
    [AddComponentMenu("ZL/Server/PUN/Lobby Manager (PUN)")]

    [DisallowMultipleComponent]

    public sealed class LobbyManager_PUN : MonoBehaviourPunCallbacks
    {
        [Space]

        [SerializeField]

        private string currentLobbyName = string.Empty;

        [Space]

        [SerializeField]

        private TypedLobby[] lobbies;

        private Dictionary<string, TypedLobby> lobbyDictionary;

        private void Awake()
        {
            lobbyDictionary = new(lobbies.Length);

            foreach (var lobby in lobbies)
            {
                lobbyDictionary.Add(lobby.Name, lobby);
            }

            lobbies = null;
        }

        public void JoinLobby(string name)
        {
            currentLobbyName = name;

            PhotonNetwork.JoinLobby(lobbyDictionary[name]);
        }

        public void LeaveLobby()
        {
            PhotonNetwork.LeaveLobby();
        }

        public override void OnJoinedLobby()
        {
            Debug.Log($"로비 입장: {currentLobbyName}");
        }

        public override void OnLeftLobby()
        {
            Debug.Log($"로비 퇴장: {currentLobbyName}");
        }

        public override void OnJoinedRoom()
        {
            
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("방 참여 실패");

            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }
    }
}