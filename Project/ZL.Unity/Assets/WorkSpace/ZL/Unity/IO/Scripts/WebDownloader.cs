using System.Collections;

using System.IO;

using UnityEngine;

using UnityEngine.Networking;

using ZL.Unity.Singleton;

namespace ZL.Unity.Networking
{
    [AddComponentMenu("ZL/Networking/Web Download Manager")]

    [DisallowMultipleComponent]

    public sealed class WebDownloader : MonoSingleton<WebDownloader>
    {
        public void DownloadFileFromWeb(string url, string filePath)
        {
            if (downloadFileFromWebRoutine != null)
            {
                return;
            }

            downloadFileFromWebRoutine = DownloadFileFromWebRoutine(url, filePath);

            StartCoroutine(downloadFileFromWebRoutine);
        }

        private IEnumerator downloadFileFromWebRoutine = null;

        private IEnumerator DownloadFileFromWebRoutine(string url, string path)
        {
            var www = UnityWebRequest.Get(url);

            yield return www.SendWebRequest();

            UnityWebRequest.Result result = www.result;

            if (result == UnityWebRequest.Result.Success)
            {
                var data = www.downloadHandler.data;

                File.WriteAllBytes(path, data);
            }

            downloadFileFromWebRoutine = null;
        }
    }
}