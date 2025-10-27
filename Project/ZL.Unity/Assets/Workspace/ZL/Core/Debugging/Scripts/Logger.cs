#if UNITY_EDITOR

using UnityEngine;

namespace ZL.Unity.Debugging
{
    /// <summary>
    /// [ENG] Warning! This component is for debugging purposes only and is excluded from the build.<br/>
    /// [KOR] ���! �� ���� ��Ҵ� ����� �������θ� ���Ǹ� ���忡�� ���ܵ˴ϴ�.<br/>
    /// </summary>
    [AddComponentMenu("ZL/Debugging/Logger")]

    public sealed class Logger : MonoBehaviour
    {
        [Space]

        [WarningBox("[ENG] Warning! This component is for debugging purposes only and is excluded from the build.")]

        [WarningBox("[KOR] ���! �� ���� ��Ҵ� ����� �������θ� ���Ǹ� ���忡�� ���ܵ˴ϴ�.")]

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