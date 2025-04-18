using System.Collections;

using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.Tweeners;

using ZL.Unity.UI;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Scene Director (Singleton)")]

    public class SceneDirector : SceneDirector<SceneDirector>
    {

    }

    [DisallowMultipleComponent]

    public abstract class SceneDirector<TSceneDirector> : Singleton<TSceneDirector>

        where TSceneDirector : SceneDirector<TSceneDirector>
    {
        [Space]

        [SerializeField]

        protected UGUIScreen fadeScreen;

        [SerializeField]

        protected float startDelay = 0f;

        private int pauseCount = 0;

        protected virtual IEnumerator Start()
        {
            FadeIn();

            yield return WaitFor.Seconds(startDelay);
        }

        public virtual void FadeScene(string loadSceneName)
        {
            FadeOut();

            FixedSceneManager.LoadScene(this, startDelay, loadSceneName);
        }

        public void FadeIn()
        {
            ISingleton<AudioListenerVolumeTweener>.Instance?.Tween(1f);

            fadeScreen?.FadeOut();
        }

        public void FadeOut()
        {
            ISingleton<AudioListenerVolumeTweener>.Instance?.Tween(0f);

            fadeScreen?.FadeIn();
        }

        public void Pause()
        {
            ++pauseCount;

            Time.timeScale = 0f;
        }

        public void Resume()
        {
            if (--pauseCount <= 0)
            {
                pauseCount = 0;

                Time.timeScale = 1f;
            }
        }

        public void Quit()
        {
            FixedApplication.Quit();
        }
    }
}