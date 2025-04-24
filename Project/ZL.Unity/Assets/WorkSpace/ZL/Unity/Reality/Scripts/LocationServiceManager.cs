using System.Collections;

using UnityEngine;

using UnityEngine.Events;

using ZL.Unity.Singleton;

namespace ZL.Unity.Reality
{
    [AddComponentMenu("ZL/Reality/Location Service Manager (Singleton)")]

    public sealed class LocationServiceManager : MonoSingleton<LocationServiceManager>
    {
        [Space]

        [SerializeField]

        private float maxInitializationTime;

        [Space]

        [SerializeField]

        private UnityEvent onLocationServiceStartedEvent;

        [Space]

        [SerializeField]

        private UnityEvent onLocationServiceInitializedEvent;

        [Space]

        [SerializeField]

        private UnityEvent<LocationServiceException> onLocationServiceFailedEvent;

        [Space]

        [SerializeField]

        private UnityEvent onLocationServiceStopedEvent;

        protected override void Awake()
        {
            base.Awake();

            Input.compass.enabled = true;
        }

        public void StartLocationService(float desiredAccuracyInMeters, float updateDistanceInMeters)
        {
            if (locationServiceRoutine != null)
            {
                return;
            }

            locationServiceRoutine = LocationServiceRoutine(desiredAccuracyInMeters, updateDistanceInMeters);

            StartCoroutine(locationServiceRoutine);
        }

        public void StopLocationService()
        {
            if (Input.location.status != LocationServiceStatus.Stopped)
            {
                Input.location.Stop();

                OnLocationServiceStopped();
            }
        }

        private IEnumerator locationServiceRoutine = null;

        private IEnumerator LocationServiceRoutine(float desiredAccuracyInMeters, float updateDistanceInMeters)
        {
            Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);

            OnLocationServiceStarted();

            if (Input.location.isEnabledByUser == true)
            {
                OnLocationServiceFailed(LocationServiceException.Disabled);
            }

            else
            {
                var time = 0f;

                while (true)
                {
                    if (Input.location.status == LocationServiceStatus.Running)
                    {
                        OnLocationServiceInitialized();

                        break;
                    }

                    yield return null;

                    if (Input.location.status == LocationServiceStatus.Failed)
                    {
                        OnLocationServiceFailed(LocationServiceException.InitializationFailed);

                        break;
                    }

                    if (maxInitializationTime > 0f)
                    {
                        continue;
                    }
                    
                    time += Time.deltaTime;

                    if (time >= maxInitializationTime)
                    {
                        OnLocationServiceFailed(LocationServiceException.Timeout);

                        break;
                    }
                }
            }

            locationServiceRoutine = null;
        }

        private void OnLocationServiceStarted()
        {
            onLocationServiceStartedEvent.Invoke();
        }

        private void OnLocationServiceInitialized()
        {
            onLocationServiceInitializedEvent.Invoke();
        }

        private void OnLocationServiceFailed(LocationServiceException exception)
        {
            Input.location.Stop();

            onLocationServiceFailedEvent.Invoke(exception);
        }

        private void OnLocationServiceStopped()
        {
            onLocationServiceStopedEvent.Invoke();
        }
    }
}