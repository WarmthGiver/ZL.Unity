#pragma warning disable

using UnityEngine;

namespace ZL.Demo
{
    [AddComponentMenu("ZL/Demo/Logger")]

    [DisallowMultipleComponent]

    public sealed class Logger : MonoBehaviour
    {
        public void Log(string message)
        {
            FixedDebug.Log(message);
        }
    }
}