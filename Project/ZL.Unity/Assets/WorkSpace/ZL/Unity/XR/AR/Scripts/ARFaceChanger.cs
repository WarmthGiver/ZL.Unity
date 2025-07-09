// Working

#pragma warning disable

using UnityEngine;

using UnityEngine.XR.ARFoundation;

namespace ZL.Unity.XR.AR
{
    [AddComponentMenu("ZL/XR/AR/AR Face Changer")]

    public sealed class ARFaceChanger : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [Alias("AR Face Manager")]

        [UsingCustomProperty]

        [SerializeField]

        private ARFaceManager arFaceManager = null;

        [Space]

        [Essential]

        [ReadOnlyWhenPlayMode]

        [UsingCustomProperty]

        [SerializeField]

        private GameObject vertex = null;

        private void Awake()
        {
            arFaceManager.facesChanged += OnFaceChanged;
        }

        private void OnFaceChanged(ARFacesChangedEventArgs args)
        {
            if (args.updated.Count > 0)
            {
                var arFace = args.updated[0];

                for (int i = 0; i < arFace.vertices.Length; ++i)
                {
                    Vector3 pose = arFace.transform.TransformPoint(arFace.vertices[i]);
                }
            }
        }
    }
}