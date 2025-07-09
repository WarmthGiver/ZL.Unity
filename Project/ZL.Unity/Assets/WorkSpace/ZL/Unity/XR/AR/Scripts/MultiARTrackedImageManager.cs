// Working

#pragma warning disable

using UnityEngine;

using UnityEngine.XR.ARFoundation;

using ZL.Unity.Collections;

using ZL.Unity.Pooling;

namespace ZL.Unity.XR.AR
{
    [AddComponentMenu("ZL/XR/AR/Multi AR Tracked Image Manager")]

    public sealed class MultiARTrackedImageManager : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [Alias("AR Tracked Image Manager")]

        private ARTrackedImageManager arTrackedImageManager = null;

        [Space]

        [SerializeField]

        private SerializableDictionary<string, ObjectPool> prefabPools = null;

        private void Awake()
        {
            arTrackedImageManager.trackedImagesChanged += OnImageChanged;
        }

        private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
        {
            foreach (var trackedImage in args.added)
            {
                var name = trackedImage.referenceImage.name;
            }


        }
    }
}