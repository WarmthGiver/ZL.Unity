using UnityEngine;

namespace ZL
{
    public sealed class ApplicationManager : Singleton<ApplicationManager>
    {
        [Space]

        [SerializeField]

        private bool runInBackground = true;

        [Space]

        [SerializeField]

        private IntPref targetFrameRate = new("Target Frame Rate", 60);

        protected override void Awake()
        {
            base.Awake();

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