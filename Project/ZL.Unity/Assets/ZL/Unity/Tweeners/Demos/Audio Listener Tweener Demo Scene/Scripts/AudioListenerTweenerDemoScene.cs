using DG.Tweening;

using UnityEngine;

using UnityEngine.SceneManagement;

namespace ZL.Unity.Tweeners.Demo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class AudioListenerTweenerDemoScene : MonoBehaviour
    {
        private void Start()
        {
            AudioListenerTweener.volumeTweener.Tween(1f, 3f).
                
                SetEase(Ease.Linear);
        }

        private void Update()
        {
            if (Input.anyKeyDown == true)
            {
                AudioListenerTweener.volumeTweener.Tween(0f, 3f).
                    
                    SetEase(Ease.Linear).

                    OnComplete(() => SceneManager.LoadScene("Audio Listener Tweener Demo Scene"));
            }
        }
    }
}