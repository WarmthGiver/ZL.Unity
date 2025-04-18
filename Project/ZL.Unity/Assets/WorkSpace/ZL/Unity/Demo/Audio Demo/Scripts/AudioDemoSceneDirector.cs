#pragma warning disable

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL.Unity.Demo.AudioDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class AudioDemoSceneDirector : SceneDirector
	{
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [Alias("SFX Audio Source")]

        private AudioSource sfxAudioSource;

        [SerializeField]

        private AudioClip clickSFX;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                sfxAudioSource.PlayOneShot(clickSFX);
            }
        }
    }
}