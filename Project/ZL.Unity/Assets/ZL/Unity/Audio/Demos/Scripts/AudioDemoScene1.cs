#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL.Unity.Audio.Demo
{
    [DisallowMultipleComponent]

    public sealed class AudioDemoScene1 : MonoBehaviour
	{
        [Space]

        [SerializeField]

        private SFXPlayer sfxPlayer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                SceneManager.LoadScene("Audio Demo Scene 2");
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                sfxPlayer.Play();
            }
        }
    }
}