using UnityEngine;

namespace ZL
{
    [AddComponentMenu("ZL/Application Manager Receiver")]

    [DisallowMultipleComponent]

    public sealed class ApplicationManagerReceiver : MonoSingletonReceiver<ApplicationManager>
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