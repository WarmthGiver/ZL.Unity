using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

using UnityGoogleDrive;

using UnityGoogleDrive.Data;

using ZL.Unity.Singleton;

namespace ZL.Unity.GoogleDrive
{
    [AddComponentMenu("ZL/Google Drive/Google Drive Downloader (Singleton)")]

    [DefaultExecutionOrder(-1)]

    public sealed class GoogleDriveDownloader : MonoSingleton<GoogleDriveDownloader>
    {
        [Space]

        [SerializeField]

        private UnityEvent onDownloadStartedEvent;

        public UnityEvent OnDownloadStartedEvent => onDownloadStartedEvent;

        [Space]

        [SerializeField]

        private UnityEvent onDownloadEndedEvent;

        public UnityEvent OnDownloadEndedEvent => onDownloadEndedEvent;

        [Space]

        [SerializeField]

        private UnityEvent onSendRequestEvent;

        public UnityEvent OnSendRequestEvent => onSendRequestEvent;

        [Space]

        [SerializeField]

        private UnityEvent<float> onRequestProgressEvent;

        public UnityEvent<float> OnRequestProgressEvent => onRequestProgressEvent;

        private readonly Dictionary<string, Action<File>> onRequestDoneActions = new();

        private readonly Queue<string> downloadQueue = new();

        public void StartDownload(string fileID, Action<File> onRequestDoneAction = null)
        {
            if (onRequestDoneActions.ContainsKey(fileID) == false)
            {
                onRequestDoneActions.Add(fileID, onRequestDoneAction);

                downloadQueue.Enqueue(fileID);
            }

            if (downloadRoutine != null)
            {
                return;
            }

            downloadRoutine = DownloadRoutine();

            StartCoroutine(downloadRoutine);
        }

        private IEnumerator downloadRoutine = null;

        private IEnumerator DownloadRoutine()
        {
            onDownloadStartedEvent.Invoke();

            while (downloadQueue.Count != 0)
            {
                var fileID = downloadQueue.Dequeue();

                var request = GoogleDriveFiles.Download(fileID);

                onRequestDoneActions.Remove(fileID, out var onRequestDoneAction);

                request.OnDone += onRequestDoneAction;

                request.Send();

                onSendRequestEvent.Invoke();

                while (request.IsDone == false)
                {
                    yield return null;

                    onRequestProgressEvent.Invoke(request.Progress);
                }
            }

            onDownloadEndedEvent.Invoke();

            downloadRoutine = null;
        }
    }
}