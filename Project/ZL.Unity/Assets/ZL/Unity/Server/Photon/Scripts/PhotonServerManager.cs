using Photon.Pun;

using Photon.Realtime;

using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Server Manager")]

    [DisallowMultipleComponent]

    public sealed class PhotonServerManager : MonoBehaviourPunCallbacks
    {
        [Space]

        [SerializeField]

        private UnityEvent eventOnConnected;

        public UnityEvent EventOnConnectedToMaster => eventOnConnected;

        [Space]

        [SerializeField]

        private UnityEvent eventOnDisconnected;

        public UnityEvent EventOnDisconnected => eventOnConnected;

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void TryConnectToMaster()
        {
            if (PhotonNetwork.IsConnected == false)
            {
                PhotonNetwork.GameVersion = Application.unityVersion;

                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to Photon server.");

            eventOnConnected.Invoke();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarning($"Disconnected to Photon server: {cause}");

            eventOnDisconnected.Invoke();
        }
    }
}