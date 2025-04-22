using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Application Manager Receiver")]

    [DisallowMultipleComponent]

    public sealed class ApplicationManagerReceiver : SingletonReceiver<ApplicationManager>
    {
        public BoolPref RunInBackgroundPref
        {
            get => Target.RunInBackgroundPref;
        }

        public IntPref TargetFrameRatePref
        {
            get => Target.TargetFrameRatePref;
        }

        public void Quit()
        {
            Target.Quit();
        }
    }
}