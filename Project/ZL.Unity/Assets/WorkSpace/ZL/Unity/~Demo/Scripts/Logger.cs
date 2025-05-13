#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo
{
    [AddComponentMenu("ZL/Demo/Logger")]

    public sealed class Logger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private string message;

        public string Message
        {
            get => message;

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