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

        private UnityEvent eventOnConnectedToMaster;

        public UnityEvent EventOnConnectedToMaster => eventOnConnectedToMaster;

        [Space]

        [SerializeField]

        private UnityEvent eventOnDisconnected;

        public UnityEvent EventOnDisconnected => eventOnConnectedToMaster;

        private void Awake()
        {
            // 방장이 씬을 넘기면 다른 인원도 다 같이 씬을 넘김
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void TryConnectToMaster()
        {
            if (PhotonNetwork.IsConnected == false)
            {
                PhotonNetwork.GameVersion = Application.unityVersion;

                // 유니티 포톤 세팅 값을 바탕으로 서버에 연결
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        // 서버에 연결되면 호출되는 이벤트 함수
        public override void OnConnectedToMaster()
        {
            Debug.Log("서버 연결 성공");

            eventOnConnectedToMaster.Invoke();
        }

        // 서버와 연결이 끊기면 호출되는 이벤트 함수
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"서버 연결 끊김: {cause}");

            eventOnDisconnected.Invoke();
        }
    }
}