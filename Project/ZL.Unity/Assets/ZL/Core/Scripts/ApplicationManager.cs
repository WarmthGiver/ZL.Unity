using UnityEngine;

using ZL.Unity.IO;

using ZL.Unity.Singleton;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Application Manager (Singleton)")]

    public sealed class ApplicationManager : MonoSingleton<ApplicationManager>
    {
        [Space]

        [SerializeField]

        [PropertyField]

        [Button(nameof(LoadRunInBackground), "Load")]

        [Button(nameof(SaveRunInBackground), "Save")]

        [UsingCustomProperty]

        private BoolPref runInBackgroundPref = new("RunInBackground", false);

        public BoolPref RunInBackgroundPref
        {
            get => runInBackgroundPref;
        }

        [Space]

        [PropertyField]

        [Button(nameof(LoadTargetFrameRate), "Load")]

        [Button(nameof(SaveTargetFrameRate), "Save")]

        [UsingCustomProperty]

        [SerializeField]

        private IntPref targetFrameRatePref = new("TargetFrameRate", -1);

        public IntPref TargetFrameRatePref
        {
            get => targetFrameRatePref;
        }

        [Space]

        [Text("Cursor")]

        [AddIndent]

        [Alias("Visible")]

        [UsingCustomProperty]

        [SerializeField]

        private bool cursorVisible = true;

        [AddIndent]

        [Alias("Lock State")]

        [UsingCustomProperty]

        [SerializeField]

        private CursorLockMode cursorLockState = CursorLockMode.None;

        [Space]

        [PropertyField]

        [Button(nameof(Pause))]

        [Button(nameof(Resume))]

        [Button(nameof(Quit))]

        [UsingCustomProperty]

        [SerializeField]

        private float timeScale = 1f;

        private void OnValidate()
        {
            if (Application.isPlaying == false)
            {
                return;
            }

            runInBackgroundPref.Refresh();

            targetFrameRatePref.Refresh();

            Cursor.visible = cursorVisible;

            Cursor.lockState = cursorLockState;

            TimeEx.TimeScale = timeScale;
        }

        protected override void Awake()
        {
            base.Awake();

            runInBackgroundPref.OnValueChanged += (value) =>
            {
                Application.runInBackground = value;
            };

            runInBackgroundPref.TryLoadValue();

            targetFrameRatePref.OnValueChanged += (value) =>
            {
                Application.targetFrameRate = value;
            };

            targetFrameRatePref.TryLoadValue();

            Cursor.visible = cursorVisible;

            Cursor.lockState = cursorLockState;

            TimeEx.TimeScale = timeScale;
        }

        public void LoadRunInBackground()
        {
            RunInBackgroundPref.TryLoadValue();
        }

        public void SaveRunInBackground()
        {
            RunInBackgroundPref.SaveValue();
        }

        public void LoadTargetFrameRate()
        {
            TargetFrameRatePref.TryLoadValue();
        }

        public void SaveTargetFrameRate()
        {
            TargetFrameRatePref.SaveValue();
        }

        public void Pause()
        {
            TimeEx.Pause();

            timeScale = TimeEx.TimeScale;
        }

        public void Resume()
        {
            TimeEx.Resume();

            timeScale = TimeEx.TimeScale;
        }

        public void Quit()
        {
            FixedApplication.Quit();
        }
    }
}