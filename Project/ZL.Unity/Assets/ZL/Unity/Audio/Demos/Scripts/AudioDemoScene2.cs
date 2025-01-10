using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.ObjectPooling;

namespace ZL.Unity.Audio.Demo
{
    [DisallowMultipleComponent]

    public sealed class AudioDemoScene2 : MonoBehaviour
	{
        [Space]

        [SerializeField]

        private PooledAudioSourcePlayer sfxPlayer;

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