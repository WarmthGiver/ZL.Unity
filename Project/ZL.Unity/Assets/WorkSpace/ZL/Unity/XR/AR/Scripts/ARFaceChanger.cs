using UnityEngine;

using UnityEngine.XR.ARFoundation;

namespace ZL.Unity.XR.AR
{
    [AddComponentMenu("ZL/XR/AR/AR Face Changer")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(ARFaceManager))]

    public sealed class ARFaceChanger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        [Alias("AR Face Manager")]

        private ARFaceManager arFaceManager;

        [Space]

        [SerializeField]

        private GameObject vertex;

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