#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Logger")]

    public sealed class Logger : MonoBehaviour
    {
        [Space]

        [WarningBox("[ENG] Warning! This component is for debugging purposes only and is excluded from the build.")]

        [WarningBox("[KOR] 경고! 이 구성 요소는 디버깅 목적으로만 사용되며 빌드에서 제외됩니다.")]

        [Margin]

        [UsingCustomProperty]

        [SerializeField]

        private string message = string.Empty;

        public string Message
        {
            set => message = value;
        }

        public void Log()
        {
            Log(message);
        }

        public void Log(string message)
        {
            FixedDebug.Log(message);
        }
    }
}

#endif