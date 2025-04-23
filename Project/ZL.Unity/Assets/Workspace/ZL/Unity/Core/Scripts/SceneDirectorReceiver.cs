using UnityEngine;

namespace ZL
{
    [AddComponentMenu("ZL/Scene Director Receiver")]

    public sealed class SceneDirectorReceiver : SceneDirectorReceiver<SceneDirector>
    {

    }

    public abstract class SceneDirectorReceiver<TSceneDirector> : MonoSingletonReceiver<TSceneDirector>

        where TSceneDirector : SceneDirector<TSceneDirector>
    {
        private void Reset()
        {
            this.DisallowMultiple();
        }

        public void LoadScene(string scaneName)
        {
            Target.FadeScene(scaneName);
        }
    }
}