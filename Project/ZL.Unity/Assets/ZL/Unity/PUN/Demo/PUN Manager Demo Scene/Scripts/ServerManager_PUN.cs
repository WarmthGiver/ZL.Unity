using Photon.Pun;

using Photon.Realtime;

using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Server.PUN
{
    [AddComponentMenu("ZL/Server/PUN/Server Manager (PUN)")]

    [DisallowMultipleComponent]

    public sealed class ServerManager_PUN : MonoBehaviourPunCallbacks
    {
        [Space]

        [SerializeField]

        private GameObject messageBox;

        [Space]

        [SerializeField]

        private string gameVersion = "1.0";

        [Space]

        [SerializeField]

        private UnityEvent eventOnConnected;

        private UnityEvent EventOnConnected => eventOnConnected;

        [Space]

        [SerializeField]

        private UnityEvent eventOnDisconnected;

        private UnityEvent EventOnDisconnected => eventOnConnected;

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void TryConnect()
        {
            if (PhotonNetwork.IsConnected == false)
            {
                PhotonNetwork.GameVersion = gameVersion;

                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("서버 연결 성공");

            eventOnConnected.Invoke();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"서버 연결 끊김: {cause}");

            eventOnDisconnected.Invoke();
        }
    }
}