using UnityEngine;

using ZL.Unity.IO;

namespace ZL.Unity
{
    [AddComponentMenu("")]

    [CreateAfterSceneLoad]

    public class ApplicationManager : MonoSingleton<ApplicationManager>
    {
        [Space]

        [SerializeField]

        private bool runInBackground = true;

        [Space]

        [SerializeField]

        private IntPref targetFrameRatePref = new("Target Frame Rate", 60);

        private void OnValidate()
        {
            Application.runInBackground = runInBackground;
        }

        protected override void Awake()
        {
            base.Awake();

            Application.runInBackground = runInBackground;

            targetFrameRatePref.OnValueChangedAction += (value) =>
            {
                Application.targetFrameRate = value;
            };

            targetFrameRatePref.TryLoadValue();

            Application.targetFrameRate = targetFrameRatePref.Value;
        }
    }
}