using System.Collections;

using UnityEngine;

using ZL.Unity.Tweeners;

using ZL.Unity.UI;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Scene Director (Singleton)")]

    public class SceneDirector : SceneDirector<SceneDirector>
    {

    }

    public abstract class SceneDirector<TSceneDirector> : Singleton<TSceneDirector>

        where TSceneDirector : SceneDirector<TSceneDirector>
    {
        [Space]

        [SerializeField]

        protected UGUIScreen fadeScreen;

        [SerializeField]

        protected float startDelay = 0f;

        private void Reset()
        {
            this.DisallowMultiple();
        }

        protected virtual IEnumerator Start()
        {
            FadeIn();

            yield return WaitFor.Seconds(startDelay);
        }

        public virtual void FadeScene(string sceneName)
        {
            FadeOut();

            FixedSceneManager.LoadScene(this, startDelay, sceneName);
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
    }
}