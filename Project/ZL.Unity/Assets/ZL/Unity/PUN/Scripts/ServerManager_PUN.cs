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

        private string gameVersion = "1.0";

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
            // ������ ���� �ѱ�� �ٸ� �ο��� �� ���� ���� �ѱ�
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void TryConnectToMaster()
        {
            if (PhotonNetwork.IsConnected == false)
            {
                PhotonNetwork.GameVersion = gameVersion;

                // ����Ƽ ���� ���� ���� �������� ������ ����
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        // ������ ����Ǹ� ȣ��Ǵ� �̺�Ʈ �Լ�
        public override void OnConnectedToMaster()
        {
            Debug.Log("���� ���� ����");

            eventOnConnectedToMaster.Invoke();
        }

        // ������ ������ ����� ȣ��Ǵ� �̺�Ʈ �Լ�
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"���� ���� ����: {cause}");

            eventOnDisconnected.Invoke();
        }
    }
}