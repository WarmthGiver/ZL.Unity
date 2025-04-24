using UnityEngine;

using UnityEngine.XR.ARFoundation;

using ZL.Unity.Collections;

using ZL.Unity.Pooling;

namespace ZL.Unity.XR.AR
{
    [AddComponentMenu("ZL/XR/AR/Multi AR Tracked Image Manager")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(ARTrackedImageManager))]

    public sealed class MultiARTrackedImageManager : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        [Alias("AR Tracked Image Manager")]

        private ARTrackedImageManager arTrackedImageManager;

        [Space]

        [SerializeField]

        private SerializableDictionary<string, ObjectPool<Transform>> prefabPools;

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