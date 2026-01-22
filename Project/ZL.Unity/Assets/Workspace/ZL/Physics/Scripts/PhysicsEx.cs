// Working

using UnityEngine;

namespace ZL.Unity
{
    public static partial class PhysicsEx
    {
        public static bool BoxCast(Vector3 origin, in Quaternion rotation, Vector3 scale, out RaycastHit raycastHit, int layerMask)
        {
            return Physics.BoxCast(origin, scale * 0.5f, Vector3.zero, out raycastHit, rotation, 0f, layerMask);
        }

        public static bool BoxCast(Vector3 origin, Vector3 end, in Quaternion rotation, Vector3 scale, out RaycastHit raycastHit, int layerMask)
        {
            return Physics.BoxCast(origin, scale * 0.5f, (end - origin).normalized, out raycastHit, rotation, Vector3.Distance(origin, end), layerMask);
        }

        public static bool BoxCastAll(Vector3 origin, in Quaternion rotation, Vector3 scale, out RaycastHit[] raycastHits, int layerMask)
        {
            raycastHits = Physics.BoxCastAll(origin, scale * 0.5f, Vector3.zero, rotation, 0f, layerMask);

            return raycastHits.Length > 0;
        }

        public static bool BoxCastAll(Vector3 origin, Vector3 end, in Quaternion rotation, Vector3 scale, out RaycastHit[] raycastHits, int layerMask)
        {
            raycastHits = Physics.BoxCastAll(origin, scale * 0.5f, (end - origin).normalized, rotation, Vector3.Distance(origin, end), layerMask);

            return raycastHits.Length > 0;
        }

        public static bool LineCast(Vector3 origin, Vector3 end, float length, out RaycastHit raycastHit, int layerMask)
        {
            return Physics.Raycast(origin, (end - origin).normalized, out raycastHit, length, layerMask);
        }

        public static bool LineCastAll(Vector3 origin, Vector3 end, out RaycastHit[] raycastHits, int layerMask)
        {
            raycastHits = Physics.RaycastAll(origin, end, Vector3.Distance(origin, end), layerMask);

            return raycastHits.Length > 0;
        }

        public static bool LineCastAll(Vector3 origin, Vector3 end, float length, out RaycastHit[] raycastHits, int layerMask)
        {
            raycastHits = Physics.RaycastAll(origin, (end - origin).normalized, length, layerMask);

            return raycastHits.Length > 0;
        }

        //-----------

        public static bool SphereCast(Vector3 origin, float radius, out RaycastHit hitInfo, int layerMask)
        {
            return Physics.SphereCast(origin, radius, Vector3.zero, out hitInfo, 0f, layerMask);
        }

        public static bool SphereCast(Vector3 origin, float radius, Vector3 destination, out RaycastHit hitInfo, int layerMask)
        {
            var difference = destination - origin;

            float distance = difference.magnitude;

            return Physics.SphereCast(origin, radius, difference / distance, out hitInfo, distance, layerMask);
        }

        public static bool SphereCastAll(Vector3 origin, float radius, RaycastHit[] results, int layerMask)
        {
            int hitCount = Physics.SphereCastNonAlloc(origin, radius, Vector3.zero, results, 0f, layerMask);

            return hitCount > 0;
        }

        public static bool SphereCastAll(Vector3 origin, float radius, Vector3 destination, RaycastHit[] results, int layerMask)
        {
            var direction = destination - origin;

            float distance = direction.magnitude;

            return SphereCastAll(origin, radius, direction / distance, results, distance, layerMask);
        }

        public static bool SphereCastAll(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance, int layerMask)
        {
            if (layerMask == 0)
            {
                return false;
            }

            int hitCount = Physics.SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask);

            return hitCount > 0;
        }
    }
}