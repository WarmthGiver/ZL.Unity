#pragma warning disable

using DG.Tweening;

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Tweeners;

namespace ZL.Unity.AudioListenerVolumeTweenerDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class AudioListenerVolumeTweenerDemoScene : MonoBehaviour
    {
#if UNITY_EDITOR

        [Space]

        [SerializeField]

        private float timeScale = 1f;

        private void OnValidate()
        {
            Time.timeScale = timeScale;
        }

#endif

        private void Start()
        {
            //ISingleton<AudioListenerVolumeTweener>.Instance.Tween(1f);
        }

        private void Update()
        {
            if (Input.anyKeyDown == true)
            {
                //ISingleton<AudioListenerVolumeTweener>.Instance.
                    
                    //Tween(0f).

                    //OnComplete(LoadScene);
            }
        }

        private void LoadScene()
        {
            SceneManager.LoadScene("Audio Listener Volume Tweener Demo Scene");
        }
    }
}