using System;

using System.Collections;

using System.IO;

using UnityEngine;

using UnityEngine.Networking;

using ZL.Unity.Singleton;

using Result = UnityEngine.Networking.UnityWebRequest.Result;

namespace ZL.Unity.Networking
{
    [AddComponentMenu("ZL/Networking/Web Download Manager (Singleton)")]

    [DisallowMultipleComponent]

    public sealed class WebDownloadManager : MonoSingleton<WebDownloadManager>
    {
        public void StartDownload(string url, string path, Action<Result> callback = null)
        {
            if (downloadRoutine != null)
            {
                return;
            }

            downloadRoutine = DownloadRoutine(url, path, callback);

            StartCoroutine(downloadRoutine);
        }

        private IEnumerator downloadRoutine = null;

        private IEnumerator DownloadRoutine(string url, string path, Action<Result> callback)
        {
            var www = UnityWebRequest.Get(url);

            yield return www.SendWebRequest();

            var result = www.result;

            if (result == Result.Success)
            {
                var data = www.downloadHandler.data;

                File.WriteAllBytes(path, data);
            }

            callback?.Invoke(result);

            downloadRoutine = null;
        }
    }
}