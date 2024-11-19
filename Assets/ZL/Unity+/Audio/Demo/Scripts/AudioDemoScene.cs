using UnityEngine;

namespace ZL
{
    using ZL.ObjectPooling;

    public class AudioDemoScene : MonoBehaviour
	{
        [Space]

        [SerializeField]

        private PooledAudioSourcePlayer sfxPlayer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                sfxPlayer.Play();
            }
        }
    }
}