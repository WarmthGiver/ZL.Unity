using Photon.Pun;

using Photon.Realtime;

using System;

using System.Collections;

using System.Collections.Generic;

using System.Diagnostics;

using UnityEngine;

using UnityEngine.Events;

using ZL.Unity.Collections;

using ZL.Unity.IO;

using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Server Manager (Singleton)")]

    [DefaultExecutionOrder(-1)]

    [DisallowMultipleComponent]

    public sealed class PhotonServerManager :
        
        MonoBehaviourPunCallbacks, ISingleton<PhotonServerManager>
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnlyWhenPlayMode]

        private StringPref nicknamePref = new("Nickname", string.Empty);

        public string Nickname
        {
            get => nicknamePref.Value;
        }

        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnlyWhenPlayMode]

        private Wrapper<TypedLobby[]> lobbies;

        [Space]

        [SerializeField]

        private float fakeLoadingTime = 0f;

        [Space]

        [SerializeField]

        private UnityEvent onConnectingToMasterEvent;

        public UnityEvent OnConnectingToMasterEvent
        {
            get => onConnectedToMasterEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onConnectedToMasterEvent;

        public UnityEvent OnConnectedToMasterEvent
        {
            get => onConnectedToMasterEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onDisconnectedEvent;

        public UnityEvent OnDisconnectedEvent
        {
            get => onConnectedToMasterEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onJoinedLobbyEvent;

        public UnityEvent OnJoinedLobbyEvent
        {
            get => onJoinedLobbyEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onLeftLobbyEvent;

        public UnityEvent OnLeftLobbyEvent
        {
            get => onLeftLobbyEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent<List<RoomInfo>> onRoomListUpdateEvent;

        public UnityEvent<List<RoomInfo>> OnRoomListUpdateEvent
        {
            get => onRoomListUpdateEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onCreatedRoomEvent;

        public UnityEvent OnCreatedRoomEvent
        {
            get => onCreatedRoomEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent<short> onCreateRoomFailedEvent;

        public UnityEvent<short> OnCreateRoomFailedEvent
        {
            get => onCreateRoomFailedEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent<Hashtable> onRoomPropertiesUpdateEvent;

        public UnityEvent<Hashtable> OnRoomPropertiesUpdateEvent
        {
            get => onRoomPropertiesUpdateEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onJoinedRoomEvent;

        public UnityEvent OnJoinedRoomEvent
        {
            get => onJoinedRoomEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent<short> onJoinRoomFailedEvent;

        public UnityEvent<short> OnJoinRoomFailedEvent
        {
            get => onJoinRoomFailedEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onLeftRoomEvent;

        public UnityEvent OnLeftRoomEvent
        {
            get => onLeftRoomEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent<Player> onPlayerEnteredRoomEvent;

        public UnityEvent<Player> OnPlayerEnteredRoomEvent
        {
            get => onPlayerEnteredRoomEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent<Player> onPlayerLeftRoomEvent;

        public UnityEvent<Player> OnPlayerLeftRoomEvent
        {
            get => onPlayerLeftRoomEvent;
        }

        [Space]

        [SerializeField]

        private UnityEvent onMasterClientSwitchedEvent;

        public UnityEvent OnMasterClientSwitchedEvent
        {
            get => onMasterClientSwitchedEvent;
        }

        private Dictionary<string, TypedLobby> lobbyDictionary;

        private readonly Stopwatch loadingStopwatch = new();

        private void Awake()
        {
            ISingleton<PhotonServerManager>.TrySetInstance(this);

            nicknamePref.OnValueChangedAction += (value) =>
            {
                PhotonNetwork.NickName = value;
            };

            nicknamePref.TryLoadValue();

            if (lobbies.value.Length != 0)
            {
                lobbyDictionary = new(lobbies.value.Length);

                foreach (var lobby in lobbies.value)
                {
                    lobbyDictionary.Add(lobby.Name, lobby);
                }
            }
        }

        private void OnDestroy()
        {
            ISingleton<PhotonServerManager>.Release(this);
        }

        public void ConnectToMaster()
        {
            OnConnectingToMaster();

            loadingStopwatch.Restart();

            if (PhotonNetwork.IsConnected == false)
            {
                PhotonNetwork.GameVersion = Application.version;

                PhotonNetwork.ConnectUsingSettings();
            }

            else
            {
                OnConnectedToMaster();
            }
        }

        public void OnConnectingToMaster()
        {
            FixedDebug.Log("Connecting To Master...");

            onConnectingToMasterEvent.Invoke();
        }

        public override void OnConnectedToMaster()
        {
            loadingStopwatch.Stop();

            float loadingTime = (float)loadingStopwatch.Elapsed.TotalSeconds;

            StartCoroutine(FakeLoading(loadingTime, () =>
            {
                FixedDebug.Log($"Connected To Master. (Version: {PhotonNetwork.GameVersion})");

                onConnectedToMasterEvent.Invoke();
            }));
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            loadingStopwatch.Stop();

            float loadingTime = (float)loadingStopwatch.Elapsed.TotalSeconds;

            StartCoroutine(FakeLoading(loadingTime, () =>
            {
                FixedDebug.LogWarning($"Disconnected: {cause}");

                onDisconnectedEvent.Invoke();
            }));
        }

        public bool TrySetNickname(string nickname, out NicknameValidationException exception)
        {
            if (nickname.IsValidNickname(out exception) == false)
            {
                FixedDebug.LogWarning($"Try Set Nickname failed: {exception}");

                return false;
            }

            nicknamePref.SaveValue(nickname);

            return true;
        }

        public void JoinLobby()
        {
            PhotonNetwork.JoinLobby();
        }

        public void JoinLobby(string name)
        {
            PhotonNetwork.JoinLobby(lobbyDictionary[name]);
        }

        public override void OnJoinedLobby()
        {
            FixedDebug.Log($"Joined lobby: {PhotonNetwork.CurrentLobby.Name}");

            onJoinedLobbyEvent.Invoke();
        }

        public void LeaveLobby()
        {
            PhotonNetwork.LeaveLobby();
        }

        public override void OnLeftLobby()
        {
            FixedDebug.Log($"Left lobby");

            onLeftLobbyEvent.Invoke();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            FixedDebug.Log($"Room list update.");

            onRoomListUpdateEvent.Invoke(roomList);
        }

        public void CreateRoom(string roomName, RoomOptions roomOptions)
        {
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        public override void OnCreatedRoom()
        {
            FixedDebug.Log($"Created room: {PhotonNetwork.CurrentRoom.Name}");

            onCreatedRoomEvent.Invoke();
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            FixedDebug.Log($"Create room failed: ({returnCode}) {message}");

            onCreateRoomFailedEvent.Invoke(returnCode);
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            FixedDebug.Log("Room Properties Update.");

            onRoomPropertiesUpdateEvent.Invoke(propertiesThatChanged);
        }

        public void JoinRoom(string roomName)
        {
            PhotonNetwork.JoinRoom(roomName);
        }

        public void JoinRandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public void JoinRandomOrCreateRoom()
        {
            PhotonNetwork.JoinRandomOrCreateRoom();
        }

        public override void OnJoinedRoom()
        {
            FixedDebug.Log($"Joined room: {PhotonNetwork.CurrentRoom.Name}");

            onJoinedRoomEvent.Invoke();
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            FixedDebug.Log($"Join room failed: ({returnCode}) {message}");

            onJoinRoomFailedEvent.Invoke(returnCode);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            FixedDebug.Log($"Join random failed: ({returnCode}) {message}");

            onJoinRoomFailedEvent.Invoke(returnCode);
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            FixedDebug.Log($"Left room.");

            onLeftRoomEvent.Invoke();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            FixedDebug.Log($"Player {newPlayer.ActorNumber} '{newPlayer.NickName}' entered room.");

            onPlayerEnteredRoomEvent.Invoke(newPlayer);

            if (PhotonNetwork.IsMasterClient == true)
            {
                var roomProperties = PhotonNetwork.CurrentRoom.CustomProperties;

                PhotonNetwork.CurrentRoom.SetCustomProperties(roomProperties);
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            FixedDebug.Log($"Player {otherPlayer.ActorNumber} '{otherPlayer.NickName}' left room.");

            onPlayerLeftRoomEvent.Invoke(otherPlayer);
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            FixedDebug.Log($"Master client switched to Player {newMasterClient.ActorNumber} '{newMasterClient.NickName}'");

            onMasterClientSwitchedEvent.Invoke();
        }

        public void SetRoomOpened(bool value)
        {
            PhotonNetwork.CurrentRoom.IsOpen = value;
        }

        private IEnumerator FakeLoading(float loadingTime, Action callback)
        {
            loadingTime = fakeLoadingTime - loadingTime;

            if (loadingTime > 0f)
            {
                yield return WaitFor.Seconds(loadingTime);
            }

            callback.Invoke();
        }
    }
}