#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL.Unity.Audio.Demo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class AudioMixerManagerDemoScene : MonoBehaviour
	{
        [Space]

        [SerializeField]

        private AudioSource audioSource;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                SceneManager.LoadScene("Audio Mixer Manager Demo Scene");
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                audioSource.Play();
            }
        }
    }
}