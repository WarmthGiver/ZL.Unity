using System;

using System.Collections;

using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.LS
{
    [AddComponentMenu("ZL/LS/Location Service Manager ")]

    [DefaultExecutionOrder(-1)]

    [DisallowMultipleComponent]

    public sealed class LocationServiceManager : MonoBehaviour
    {
        private void Awake()
        {
            Input.compass.enabled = true;

            StartInitializeLocationServiceRoutine();
        }

        public void StartInitializeLocationServiceRoutine()
        {
            if (initializeLocationServiceRoutine == null)
            {
                initializeLocationServiceRoutine = InitializeLocationServiceRoutine();

                StartCoroutine(initializeLocationServiceRoutine);
            }
        }

        private IEnumerator initializeLocationServiceRoutine = null;

        private IEnumerator InitializeLocationServiceRoutine()
        {
            if (Input.location.isEnabledByUser == true)
            {
                if (Input.location.status == LocationServiceStatus.Stopped || Input.location.status == LocationServiceStatus.Failed)
                {
                    Input.location.Start(0.1f, 0.1f);
                }

                var waitTime = 0f;

                while (Input.location.status == LocationServiceStatus.Initializing)
                {
                    yield return WaitFor.FixedUpdate();

                    waitTime += Time.fixedDeltaTime;

                    if (waitTime > 60f)
                    {
                        Input.location.Stop();

                        break;
                    }
                }
            }

            initializeLocationServiceRoutine = null;
        }

        public bool GetLocationInfo(out LocationInfo locationInfo)
        {
            if (Input.location.isEnabledByUser == true)
            {
                if (Input.location.status == LocationServiceStatus.Running)
                {
                    locationInfo = Input.location.lastData;

                    return true;
                }
            }

            locationInfo = default;

            return false;
        }

        public static double MeasureDistance(LocationInfo start, LocationInfo end, UnitOfLength unit)
        {
            double theta = start.longitude - end.longitude;

            double deg2Rad = Mathf.Deg2Rad;

            double dist = Math.Sin(deg2Rad * start.latitude) * Math.Sin(deg2Rad * end.latitude);

            dist += Math.Cos(deg2Rad * start.latitude) * Math.Cos(deg2Rad * end.latitude) * Math.Cos(deg2Rad * theta);

            dist = Math.Acos(dist) * Mathf.Rad2Deg * 69.09f; // 60f * 1.1515f

            return unit switch
            {
                UnitOfLength.Centimeter => dist * 160934.4f,

                UnitOfLength.Meter => dist * 1609.344f,

                UnitOfLength.Kilometer => dist * 1.609344,

                _ => dist
            };
        }
    }
}