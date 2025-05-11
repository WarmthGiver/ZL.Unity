using UnityEngine;

using ZL.Unity.Motions;

namespace ZL.Unity.OIIAOIIA
{
    [AddComponentMenu("ZL/OIIA OIIA")]

    [DisallowMultipleComponent]

    public sealed class OIIAOIIA : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private GameObject ethel;

        [SerializeField]

        private GameObject maxwell;

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent]

        private AudioSource audioSource;

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent]

        private Spinner spinner;

        [SerializeField]

        [UsingCustomProperty]

        [AddIndent]

        private PingPong pingPong;

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