using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Scene Director Receiver")]

    public sealed class SceneDirectorReceiver : SceneDirectorReceiver<SceneDirector>
    {

    }

    public abstract class
        
        SceneDirectorReceiver<TSceneDirector> : SingletonReceiver<TSceneDirector>

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