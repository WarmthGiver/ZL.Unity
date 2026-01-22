using System;

using UnityEngine;

using UnityEngine.AI;

namespace ZL.Unity
{
    [Serializable]

    public sealed class TransformData : IData<Transform>
    {
        [SerializeField]

        private Vector3 position;

        public Vector3 Position
        {
            get => position;
        }

        [SerializeField]

        private Quaternion rotation;

        public Quaternion Rotation
        {
            get => rotation;
        }

        [SerializeField]

        private Vector3 localScale;

        public Vector3 LocalScale
        {
            get => localScale;
        }

        public void Save(Transform transform)
        {
            position = transform.position;

            rotation = transform.rotation;

            localScale = transform.localScale;
        }

        public void Load(Transform instance)
        {
            instance.SetPositionAndRotation(position, rotation);

            instance.localScale = localScale;
        }

        public void Load(NavMeshAgent instance)
        {
            instance.Warp(position);

            instance.transform.rotation = rotation;

            instance.transform.localScale = localScale;
        }
    }
}