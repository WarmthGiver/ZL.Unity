#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL.Unity.Audio.Demo
{
    [DisallowMultipleComponent]

    public sealed class AudioDemoScene2 : MonoBehaviour
	{
        [Space]

        [SerializeField]

        private SFXPlayer sfxPlayer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                SceneManager.LoadScene("Audio Demo Scene 1");
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                sfxPlayer.Play();
            }
        }
    }
}