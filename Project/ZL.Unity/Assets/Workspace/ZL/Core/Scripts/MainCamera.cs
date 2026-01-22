using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Main Camera (Singleton)")]

    [RequireComponent(typeof(Camera))]

    public sealed class MainCamera : MonoSingleton<MainCamera>
    {
        [GetComponent]

        [Toggle(true)]

        [UsingCustomProperty]

        [SerializeField]

        private Transform _transform;

        public new Transform transform
        {
            get => _transform;
        }

        [Space]

        [Require]

        [UsingCustomProperty]

        [SerializeField]

        private Camera _camera;

        public new Camera camera
        {
            get => _camera;
        }
    }
}