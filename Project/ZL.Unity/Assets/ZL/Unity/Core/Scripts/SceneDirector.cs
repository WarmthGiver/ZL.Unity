using System.Collections;

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Tweeners;

using ZL.Unity.UI;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Scene Director")]

    [DisallowMultipleComponent]

    public sealed class SceneDirector : SceneDirector<SceneDirector> { }

    public abstract class SceneDirector<T> : MonoBehaviour, ISingleton<T>

        where T : SceneDirector<T>
    {
        [Space]

        [SerializeField]

        private CanvasGroupFader fadeScreen;

        [SerializeField]

        [UsingCustomProperty]

        [Alias("Delay")]

        private float fadeDelay = 0.5f;

        [SerializeField]

        [UsingCustomProperty]

        [Alias("Duration")]

        private float fadeDuration = 2f;

        private int pauseCall = 0;

        private void Awake()
        {
            ISingleton<T>.TrySetInstance((T)this);
        }

        private void OnDestroy()
        {
            ISingleton<T>.Release((T)this);
        }

        protected virtual IEnumerator Start()
        {
            yield return WaitFor.Seconds(fadeDelay);

            ISingleton<AudioListenerVolumeTweener>.Instance.Tween(1f);

            if (fadeScreen != null)
            {
                fadeScreen.TweenFaded(true);
            }

            yield return WaitFor.Seconds(fadeDuration);
        }

        public virtual void EndScene(bool isPlayerAlive) { }

        public void LoadScene(string scaneName)
        {
            sceneNameToLoad = scaneName;

            ISingleton<AudioListenerVolumeTweener>.Instance.Tween(0f);

            fadeScreen.TweenFaded(false);
        }

        private string sceneNameToLoad;

        protected virtual void OnSceneLoaded()
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }

        public void Pause()
        {
            ++pauseCall;

            Time.timeScale = 0f;
        }

        public void Resume()
        {
            if (--pauseCall <= 0)
            {
                pauseCall = 0;

                Time.timeScale = 1f;
            }
        }

        public void Quit()
        {
            FixedApplication.Quit();
        }
    }
}