using UnityEngine;

namespace ZL.Unity.OIIAOIIA
{
    [AddComponentMenu("ZL/OIIA OIIA")]

    public sealed class OIIAOIIA : MonoBehaviour
    {
        [Space]

        [GetComponent]

        [Essential]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private AudioSource audioSource = null;

        [Space]

        [Essential]

        [ReadOnlyIfPlayMode]

        [UsingCustomProperty]

        [SerializeField]

        private GameObject ethel = null;

        [Essential]

        [ReadOnlyIfPlayMode]

        [UsingCustomProperty]

        [SerializeField]

        private GameObject maxwell = null;

        [Essential]

        [ReadOnlyIfPlayMode]

        [AddIndent]

        [UsingCustomProperty]

        [SerializeField]

        private Spinner spinner = null;

        [Essential]

        [ReadOnlyIfPlayMode]

        [AddIndent]

        [UsingCustomProperty]

        [SerializeField]

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

                audioSource.Play(isOIIA);

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

        private void OnValidate()
        {
            IsOIIA = isOIIA;

            Speed = speed;
        }

        public void ToggleOIIA()
        {
            IsOIIA = !isOIIA;
        }
    }
}