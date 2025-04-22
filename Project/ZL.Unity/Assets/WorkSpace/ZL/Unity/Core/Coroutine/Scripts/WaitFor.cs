using System.Collections.Generic;

using UnityEngine;

namespace ZL.Unity
{
	public static class WaitFor
	{
        private static readonly WaitForEndOfFrame waitForEndOfFrame = new();

        private static readonly WaitForFixedUpdate waitForFixedUpdate = new();

        private static readonly Dictionary<float, WaitForSeconds>
            
            waitForSecondsDictionary = new(new FloatComparer());

        private static readonly Dictionary<float, WaitForSecondsRealtime>
            
            waitForSecondsRealtimeDictionary = new(new FloatComparer());

        public static WaitForEndOfFrame EndOfFrame()
        {
            return waitForEndOfFrame;
        }

        public static WaitForFixedUpdate FixedUpdate()
        {
            return waitForFixedUpdate;
        }

        public static WaitForSeconds Seconds(float seconds)
        {
            if (waitForSecondsDictionary.TryGetValue
                
                (seconds, out var waitForSeconds) == false)
            {
                waitForSecondsDictionary.Add(seconds, waitForSeconds = new(seconds));
            }

            return waitForSeconds;
        }

        public static WaitForSecondsRealtime SecondsRealtime(float seconds)
        {
            if (waitForSecondsRealtimeDictionary.TryGetValue
                
                (seconds, out var waitForSecondsRealtime) == false)
            {
                waitForSecondsRealtimeDictionary.Add(seconds, waitForSecondsRealtime = new(seconds));
            }

            return waitForSecondsRealtime;
        }

        private class FloatComparer : IEqualityComparer<float>
        {
            bool IEqualityComparer<float>.Equals(float x, float y)
            {
                return x == y;
            }

            int IEqualityComparer<float>.GetHashCode(float obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}