using Photon.Pun;

using Photon.Realtime;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Lobby Manager")]

    [DisallowMultipleComponent]

    public sealed class PhotonLobbyManager : MonoBehaviourPunCallbacks, ISingleton<PhotonLobbyManager>
    {
        [Space]

        [SerializeField]

        private TypedLobby[] lobbies;

        [Space]

        [SerializeField]

        private UnityEvent eventOnJoinedLobby;

        [Space]

        [SerializeField]

        private UnityEvent evenOnLeftLobby;

        private Dictionary<string, TypedLobby> lobbyDictionary;

        private string currentLobbyName = null;

        private void Awake()
        {
            lobbyDictionary = new(lobbies.Length);

            foreach (var lobby in lobbies)
            {
                lobbyDictionary.Add(lobby.Name, lobby);
            }
        }

        public void JoinLobby(string name)
        {
            currentLobbyName = name;

            PhotonNetwork.JoinLobby(lobbyDictionary[name]);
        }

        public override void OnJoinedLobby()
        {
            FixedDebug.Log($"Joined Lobby: {currentLobbyName}");

            eventOnJoinedLobby.Invoke();
        }

        public void LeaveLobby()
        {
            PhotonNetwork.LeaveLobby();
        }

        public override void OnLeftLobby()
        {
            FixedDebug.Log($"Left Lobby: {currentLobbyName}");

            currentLobbyName = null;

            evenOnLeftLobby.Invoke();
        }
    }
}