using System;

using System.Diagnostics;

using System.Reflection;

using UnityEngine;

using Base = UnityEngine.Debug;

namespace ZL.Fixed
{
    public static class Debug
    {
        [Conditional("UNITY_EDITOR")]

        public static void Assert(bool condition, object message, UnityEngine.Object context = null)
        {
            Base.Assert(condition, message, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void Assert(bool condition, object message)
        {
            Base.Assert(condition, message);
        }

        [Conditional("UNITY_EDITOR")]

        public static void Assert(bool condition, UnityEngine.Object context = null)
        {
            Base.Assert(condition, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void AssertFormat(bool condition, UnityEngine.Object context, string format, params object[] args)
        {
            Base.AssertFormat(condition, context, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void AssertFormat(bool condition, string format, params object[] args)
        {
            Base.AssertFormat(condition, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void Log(object message, UnityEngine.Object context = null)
        {
            Base.Log(message, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
        {
            Base.LogFormat(context, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogFormat(string format, params object[] args)
        {
            Base.LogFormat(format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogFormat(LogType logType, LogOption logOptions, UnityEngine.Object context, string format, params object[] args)
        {
            Base.LogFormat(logType, logOptions, context, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogFormat(LogType logType, LogOption logOptions, string format, params object[] args)
        {
            Base.LogFormat(logType, logOptions, null, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogAssertion(object message, UnityEngine.Object context = null)
        {
            Base.LogAssertion(message, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogAssertionFormat(UnityEngine.Object context, string format, params object[] args)
        {
            Base.LogAssertionFormat(context, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogAssertionFormat(string format, params object[] args)
        {
            Base.LogAssertionFormat(format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogWarning(object message, UnityEngine.Object context = null)
        {
            Base.LogWarning(message, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
        {
            Base.LogWarningFormat(context, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogWarningFormat(string format, params object[] args)
        {
            Base.LogWarningFormat(format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogError(object message, UnityEngine.Object context = null)
        {
            Base.LogError(message, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args)
        {
            Base.LogErrorFormat(context, format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogErrorFormat(string format, params object[] args)
        {
            Base.LogErrorFormat(format, args);
        }

        [Conditional("UNITY_EDITOR")]

        public static void LogException(Exception exception, UnityEngine.Object context = null)
        {
            Base.LogException(exception, context);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawLine(in Vector3 start, in Vector3 end)
        {
            Base.DrawLine(start, end);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawLine(in Vector3 start, in Vector3 end, in Color color)
        {
            Base.DrawLine(start, end, color);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawLine(in Vector3 start, in Vector3 end, in Color color, float duration)
        {
            Base.DrawLine(start, end, color, duration);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawLine(in Vector3 start, in Vector3 end, in Color color, float duration, bool depthTest)
        {
            Base.DrawLine(start, end, color, duration, depthTest);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawRay(in Vector3 start, in Vector3 dir, in Color color, float duration, bool depthTest)
        {
            Base.DrawRay(start, dir, color, duration, depthTest);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawRay(in Vector3 start, in Vector3 dir, in Color color, float duration)
        {
            Base.DrawRay(start, dir, color, duration);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawRay(in Vector3 start, in Vector3 dir, in Color color)
        {
            Base.DrawRay(start, dir, color);
        }

        [Conditional("UNITY_EDITOR")]

        public static void DrawRay(in Vector3 start, in Vector3 dir)
        {
            Base.DrawRay(start, dir);
        }

        [Conditional("UNITY_EDITOR")]

        public static void ClearLog()
        {
#if UNITY_EDITOR

            Assembly.GetAssembly(typeof(UnityEditor.Editor)).

                GetType("UnityEditor.LogEntries").

                GetMethod("Clear").

                Invoke(new object(), null);

#endif
        }
    }
}