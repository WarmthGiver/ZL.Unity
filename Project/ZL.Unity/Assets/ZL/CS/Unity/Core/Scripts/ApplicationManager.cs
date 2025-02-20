using UnityEngine;

using ZL.CS.Unity.IO;

namespace ZL.CS.Unity
{
    [CreateAfterSceneLoad]

    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }

        [Space]

        [SerializeField]

        private bool runInBackground = true;

        [Space]

        [SerializeField]

        private IntPref targetFrameRate = new("Target Frame Rate", 60);

        private void Awake()
        {
            Instance = this;

            Application.runInBackground = runInBackground;

            targetFrameRate.TryLoadValue();

            Application.targetFrameRate = targetFrameRate.Value;
        }

        private void OnValidate()
        {
            Application.runInBackground = runInBackground;
        }

        public static void TargetFrameRate(int value)
        {
            Instance.targetFrameRate.Value = value;

            Application.targetFrameRate = value;
        }
    }
}