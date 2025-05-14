using UnityEngine;

namespace ZL.Unity.OIIAOIIA
{
    [AddComponentMenu("ZL/OIIA OIIA")]

    public sealed class OIIAOIIA : MonoBehaviour
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        private GameObject ethel = null;

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        private GameObject maxwell = null;

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        [AddIndent]

        private AudioSource audioSource = null;

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        [AddIndent]

        private Spinner spinner = null;

        [SerializeField]

        [UsingCustomProperty]

        [Essential]

        [ReadOnlyWhenPlayMode]

        [AddIndent]

        private PingPong pingPong = null;

        [Space]

        [SerializeField]

        private bool isOIIA = false;

        public bool IsOIIA
        {
            get => isOIIA;

            set
            {
                isOIIA = value;

                ethel.SetActive(!isOIIA);

                maxwell.SetActive(isOIIA);
            }
        }

        [SerializeField]

        private float speed = 1f;

        public float Speed
        {
            get => speed;

            set
            {
                speed = value;

                audioSource.pitch = speed;

                spinner.speed = speed;

                pingPong.speed = speed;
            }
        }

        #if UNITY_EDITOR

        private void Update()
        {
            IsOIIA = isOIIA;

            Speed = speed;
        }

        #endif

        public void ToggleOIIA()
        {
            isOIIA = !isOIIA;
        }
    }
}