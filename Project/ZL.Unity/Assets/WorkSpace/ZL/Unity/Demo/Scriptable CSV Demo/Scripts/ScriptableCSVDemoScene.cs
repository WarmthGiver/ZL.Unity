#pragma warning disable

using UnityEngine;

using ZL.Unity.GoogleDrive;

namespace ZL.Unity.Demo.ScriptableCSVDemo
{
    [AddComponentMenu("")]

    public sealed class ScriptableCSVDemoScene : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private string fileID;

        [Space]

        [SerializeField]

        private PlayerData[] playerDatas;

        private void Awake()
        {
            GoogleDriveDownloader.Instance.StartDownload(fileID, (file) =>
            {
                Debug.Log(file);
            });
        }
    }
}