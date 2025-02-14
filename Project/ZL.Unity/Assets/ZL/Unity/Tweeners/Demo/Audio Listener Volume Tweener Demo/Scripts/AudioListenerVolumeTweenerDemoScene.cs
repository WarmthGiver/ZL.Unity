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
        private void Start()
        {
            AudioListenerVolumeTweener.Tween(1f, 3f).SetEase(Ease.Linear);
        }

        private void Update()
        {
            if (Input.anyKeyDown == true)
            {
                AudioListenerVolumeTweener.Tween(0f, 3f).
                    
                    SetEase(Ease.Linear).

                    OnComplete(LoadScene);
            }
        }

        private void LoadScene()
        {
            SceneManager.LoadScene("Audio Listener Volume Tweener Demo Scene");
        }
    }
}