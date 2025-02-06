#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL.Unity.Audio.Demo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class AudioDemoScene : MonoBehaviour
	{
        [Space]

        [SerializeField]

        private AudioSource audioSource;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                audioSource.Play();
            }

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                SceneManager.LoadScene("Audio Demo Scene");
            }
        }
    }
}