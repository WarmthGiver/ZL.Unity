using Photon.Pun;

using Photon.Realtime;

using System;

using System.Collections;

using System.Diagnostics;

using UnityEngine;

using UnityEngine.Events;

using ZL.Unity.Collections;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Server Manger (Singleton)")]

    [DisallowMultipleComponent]

    public sealed class PhotonServerManager :

        MonoBehaviourPunCallbacks, ISingleton<PhotonServerManager>
    {
        [Space]

        [SerializeField]

        private float fakeLoadingTime = 0f;

        [Space]

        [SerializeField]

        private UnityEvent eventOnConnecting;

        public UnityEvent EventOnConnecting => eventOnConnected;

        [Space]

        [SerializeField]

        private UnityEvent eventOnConnected;

        public UnityEvent EventOnConnectedToMaster => eventOnConnected;

        [Space]

        [SerializeField]

        private UnityEvent eventOnDisconnected;

        public UnityEvent EventOnDisconnected => eventOnConnected;

        private readonly Stopwatch loadingStopwatch = new();

        private void Awake()
        {
            ISingleton<PhotonServerManager>.TrySetInstance(this);
        }

        private void OnDestroy()
        {
            ISingleton<PhotonServerManager>.Release(this);
        }

        public void TryConnectToMaster()
        {
            eventOnConnecting.Invoke();

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

        public override void OnConnectedToMaster()
        {
            loadingStopwatch.Stop();

            float loadingTime = (float)loadingStopwatch.Elapsed.TotalSeconds;

            StartCoroutine(FakeLoading(fakeLoadingTime - loadingTime, () =>
            {
                FixedDebug.Log("Connected to Photon server.");

                eventOnConnected.Invoke();
            }));
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            loadingStopwatch.Stop();

            float loadingTime = (float)loadingStopwatch.Elapsed.TotalSeconds;

            StartCoroutine(FakeLoading(fakeLoadingTime - loadingTime, () =>
            {
                FixedDebug.LogWarning($"Disconnected to Photon server: {cause}");

                eventOnDisconnected.Invoke();
            }));
        }

        private IEnumerator FakeLoading(float time, Action callback)
        {
            if (time > 0f)
            {
                yield return WaitFor.Seconds(time);
            }

            callback.Invoke();
        }
    }
}