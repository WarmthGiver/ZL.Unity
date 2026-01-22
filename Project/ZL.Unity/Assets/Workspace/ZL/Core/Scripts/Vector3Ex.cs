using UnityEngine;

using UnityEngine.Animations;

namespace ZL.Unity
{
    public static partial class Vector3Ex
    {
        public static readonly Vector3 Half = new Vector3(0.5f, 0.5f, 0.5f);

        public static Color ToColor(this Vector3 instance)
        {
            instance = Absoulute(instance);

            float max = GetMaxAxis(instance);

            if (max > 1f)
            {
                instance *= 1f / max;
            }

            return new Color(instance.x, instance.y, instance.z);
        }

        public static Vector3 Absoulute(this Vector3 instance)
        {
            if (instance.x < 0)
            {
                instance.x = -instance.x;
            }

            if (instance.y < 0)
            {
                instance.y = -instance.y;
            }

            if (instance.z < 0)
            {
                instance.z = -instance.z;
            }

            return instance;
        }

        public static float GetMinAxis(this Vector3 instance)
        {
            float min = instance.x;

            if (min > instance.y)
            {
                min = instance.y;
            }

            if (min > instance.z)
            {
                min = instance.z;
            }

            return min;
        }

        public static float GetMaxAxis(this Vector3 instance)
        {
            float max = instance.x;

            if (max < instance.y)
            {
                max = instance.y;
            }

            if (max < instance.z)
            {
                max = instance.z;
            }

            return max;
        }

        public static Vector3 UniformMax(this Vector3 instance)
        {
            float max = instance.GetMaxAxis();

            return new Vector3(max, max, max);
        }

        public static Vector3 Direction(Vector3 from, Vector3 to, Axis ignoreAxes)
        {
            var result = Vector3.zero;

            if (!ignoreAxes.HasFlag(Axis.X))
            {
                result.x = to.x - from.x;
            }

            if (!ignoreAxes.HasFlag(Axis.Y))
            {
                result.y = to.y - from.y;
            }

            if (!ignoreAxes.HasFlag(Axis.Z))
            {
                result.z = to.z - from.z;
            }

            return result;
        }

        public static bool CheckSector(Vector3 forward, Vector3 direction, float cosHalfAngle, float radius, out float distance)
        {
            distance = direction.magnitude;

            if (distance > radius)
            {
                distance = 0f;

                return false;
            }
  
            return CheckSector(forward, direction / distance, cosHalfAngle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forward">
        /// [ENG] This parameter must be normalized.<br/>
        /// [KOR] 이 매개변수는 정규화되어야 합니다.
        /// </param>
        /// <param name="direction">
        /// [ENG] This parameter must be normalized.<br/>
        /// [KOR] 이 매개변수는 정규화되어야 합니다.
        /// </param>
        /// <param name="cosHalfAngle">
        /// [ENG] Use cached value(Mathf.Cos (angle * 0.5f * Mathf.Deg2Rad)) For optimization.<br/>
        /// [KOR] 최적화를 위해 캐싱된 값(Mathf.Cos (angle * 0.5f * Mathf.Deg2Rad))을 사용하십시오.
        /// </param>
        /// <returns></returns>
        public static bool CheckSector(Vector3 forward, Vector3 direction, float cosHalfAngle)
        {
            return Vector3.Dot(forward, direction) >= cosHalfAngle;
        }

        public static Vector3 Reverse(this Vector3 instance, Vector3 axis)
        {
            return 2f * Vector3.Dot(instance, axis) * axis - instance;
        }
    }
}