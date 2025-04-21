#pragma warning disable

using UnityEngine;

namespace ZL.Unity.Demo
{
    [AddComponentMenu("ZL/Unity/Demo/Logger")]

    [DisallowMultipleComponent]

    public sealed class Logger : MonoBehaviour
    {
        public void Log(string message)
        {
            FixedDebug.Log(message);
        }
    }
}